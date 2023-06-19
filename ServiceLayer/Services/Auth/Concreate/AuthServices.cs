using DataLayer.Auth;
using DataLayer.Auth.JwtTokens;
using DataLayer.Repository;
using DomainLayer.Entities.HL;
using DomainLayer.Exceptions;
using EFCore.NamingConventions.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Validations;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Services;
public class AuthServices : IAuthServices
{
    private readonly IUserRepository userRepository;
    private readonly IJwtTokenHandler jwtTokenHandler;
    private readonly IPasswordHasher passwordHasher;
    private readonly JwtOptions options;
    public AuthServices(
        IUserRepository userRepository,
        IJwtTokenHandler jwtTokenHandler,
        IPasswordHasher passwordHasher,
        IOptions<JwtOptions> options)
    {
        this.userRepository = userRepository;
        this.jwtTokenHandler = jwtTokenHandler;
        this.passwordHasher = passwordHasher;
        this.options = options.Value;
    }
    public User User { get; set; }

    public async ValueTask<TokenDto> LoginAsync(AuthDlDto authentificationDto)
    {
        var storageUser = await userRepository
            .SelectByIdWithDetailsAsync(
                expression: user => user.Email == authentificationDto.email,
                includes: new string[] {nameof(User.Role), nameof(User.Organization)});

        User = storageUser;

        ValidationStorageObj
            .GenericValidation<User>(storageUser, User.Id);

        if (!passwordHasher.Verify(
            hash: storageUser.PasswordHash,
            password: authentificationDto.password,
            salt: storageUser.Salt))
        {
            throw new ValidationExceptions("Username or password is not valid");
        }

        string refreshToken = jwtTokenHandler
            .GenerateRefreshToken();

        storageUser.UpdateRefreshToken(refreshToken);

        var updatedUser = await this.userRepository
            .UpdateAsync(storageUser);

        var accessToken = jwtTokenHandler
            .GenerateAccessToken(updatedUser);

        return new TokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(accessToken),
            refreshToken: storageUser.RefreshToken,
            expiredDate: accessToken.ValidTo);
    }
    public async ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDlDto refreshTokenDto)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = options.Audience,
            ValidateIssuer = true,
            ValidIssuer = options.Issuer,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(options.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(
            token: refreshTokenDto.accessToken,
            validationParameters: tokenValidationParameters,
            validatedToken: out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ValidationException("Invalid token");
        }

        var userId = principal.FindFirstValue(ClaimNames.Id);

        var storageUser = await userRepository
            .SelectByIdAsync(int.Parse(userId));

        if (!storageUser.RefreshToken.Equals(refreshTokenDto.refreshToken))
        {
            throw new ValidationException("Refresh token is not valid");
        }

        if (storageUser.RefreshTokenExpiredDate <= DateTime.UtcNow)
        {
            throw new ValidationException("Refresh token has already been expired");
        }

        var newAccessToken = jwtTokenHandler
            .GenerateAccessToken(storageUser);

        return new TokenDto(
            accessToken: new JwtSecurityTokenHandler()
                .WriteToken(newAccessToken),

            refreshToken: storageUser.RefreshToken,
            expiredDate: newAccessToken.ValidTo);
    }
}
