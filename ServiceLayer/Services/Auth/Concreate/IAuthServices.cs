namespace ServiceLayer.Services;
public interface IAuthServices
{
    ValueTask<TokenDto> LoginAsync(AuthDlDto authentificationDto);
    ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDlDto refreshTokenDto);
}
