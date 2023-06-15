using DataLayer.Auth;
using DataLayer.Auth.JwtTokens;
using DataLayer.Repository;
using DomainLayer.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

    public async ValueTask<TokenDto> LoginAsync(AuthDlDto authentificationDto)
    {
        var user = await userRepository
            .SelectByIdWithDetailsAsync(
                expression: user => user.Email == authentificationDto.email,
                includes: Array.Empty<string>());

        if (user is null)
        {
            throw new NotFoundException("User with given credentials not found");
        }

        if (!passwordHasher.Verify(
            hash: user.PasswordHash,
            password: authentificationDto.password,
            salt: user.Salt))
        {
            throw new ValidationExceptions("Username or password is not valid");
        }

        string refreshToken = jwtTokenHandler
            .GenerateRefreshToken();

        user.UpdateRefreshToken(refreshToken);

        var updatedUser = await userRepository
            .UpdateAsync(user);

        var accessToken = jwtTokenHandler
            .GenerateAccessToken(updatedUser);

        return new TokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(accessToken),
            refreshToken: user.RefreshToken,
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
