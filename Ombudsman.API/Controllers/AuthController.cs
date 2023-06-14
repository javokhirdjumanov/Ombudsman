using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthServices authServices;
    public AuthController(IAuthServices authServices)
    {
        this.authServices = authServices;
    }

    [HttpPost]
    public async ValueTask<ActionResult<TokenDto>> LoginAsync(
        AuthDlDto authDlDto)
    {
        var tokenDto = await this.authServices.LoginAsync(authDlDto);

        return Ok(tokenDto);
    }

    [HttpPost("refresh-token")]
    public async ValueTask<ActionResult<TokenDto>> RefreshTokenAsync(
        RefreshTokenDlDto refreshTokenDlDto)
    {
        var tokenDto = await this.authServices.RefreshTokenAsync(refreshTokenDlDto);

        return Ok(tokenDto);
    }
}