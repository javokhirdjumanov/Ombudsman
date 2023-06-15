using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StateProgramController : ControllerBase
{
    private readonly IStateProgramService stateProgramService;
    public StateProgramController(IStateProgramService stateProgramService)
    {
        this.stateProgramService = stateProgramService;
    }
    [HttpPost]
    public async ValueTask<ActionResult<SPDto>> PostStateProgramAsync(SPDlDto spDlDto)
    {
        var newStateProgram = await this.stateProgramService
            .CreateStateProgramAsync(spDlDto);

        return Created("", newStateProgram);
    }
    [HttpGet("all")]
    public IActionResult GetAllStatePrograms()
    {
        var statePrograms = this.stateProgramService
            .GetListStateProgramAsync();

        return Ok(statePrograms);
    }
    [HttpDelete("{id:int}")]
    public async ValueTask<ActionResult<SPDto>> DeleteStateProgramAsync(int id)
    {
        var removedStateProgram = await this.stateProgramService.DeleteStateProgramAsync(id);

        return Ok(removedStateProgram);
    }
}
