namespace ServiceLayer.Services;
public class AuthServices : IAuthServices
{
    public ValueTask<TokenDto> LoginAsync(AuthDlDto authentificationDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDlDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }
}
