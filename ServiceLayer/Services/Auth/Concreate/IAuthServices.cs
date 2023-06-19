using DomainLayer.Entities.HL;
using System.Runtime;

namespace ServiceLayer.Services;
public interface IAuthServices
{
    public User User { get; set; }
    ValueTask<TokenDto> LoginAsync(AuthDlDto authentificationDto);
    ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDlDto refreshTokenDto);
}
