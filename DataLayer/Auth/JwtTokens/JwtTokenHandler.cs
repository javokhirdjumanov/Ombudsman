using DataLayer.Auth.JwtTokens;
using DomainLayer.Entities.HL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DataLayer.Auth;

public class JwtTokenHandler : IJwtTokenHandler
{
    private readonly JwtOptions jwtOptions;
    public JwtTokenHandler(IOptions<JwtOptions> options)
    {
        this.jwtOptions = options.Value;
    }

    public JwtSecurityToken GenerateAccessToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimNames.Id, user.Id.ToString()),
            new Claim(ClaimNames.LanguageId, user.LanguageId.ToString()),
            new Claim(ClaimNames.OrganizationId, user.OrganizationId.ToString()),
            new Claim(ClaimNames.Role, user.RoleId.ToString())
        };

        var authSingingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey));

        var token = new JwtSecurityToken(
            issuer: this.jwtOptions.Issuer,
            audience: this.jwtOptions.Audience,
            expires: DateTime.Now.AddMinutes(this.jwtOptions.ExpirationInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(
                key: authSingingKey,
                algorithm: SecurityAlgorithms.HmacSha256)
            );

        return token;
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        using var randomGenerator = RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}