using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<int>> CreateAsync(UserCreateDlDto cDto)
    {
        var newUser = await this.userService
            .CreateAsync(cDto);

        return Created("", newUser);
    }
    [HttpGet]
    public IActionResult SelectList()
    {
        var users = this.userService
            .SelectList();

        return Ok(users);
    }
    [HttpGet("{id:int}")]
    [Authorize]
    public async ValueTask<ActionResult<UserDto>> SelectByIdAsync(int id)
    {
        var user = await this.userService
            .SelectByIdAsync(id);

        return Ok(user);
    }
    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> UpdateAsync(UserModifyDlDto mDto)
    {
        var modifyUser = await this.userService
            .UpdateAsync(mDto);

        return Ok(modifyUser);
    }
    [HttpDelete]
    public async ValueTask<ActionResult<int>> DeleteAsync(int id)
    {
        var removedUser = await this.userService
            .DeleteAsync(id);

        return Ok(removedUser);
    }
}
