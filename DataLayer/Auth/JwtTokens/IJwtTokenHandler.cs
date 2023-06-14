using DomainLayer.Entities.HL;
using System.IdentityModel.Tokens.Jwt;

namespace DataLayer.Auth;
public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
