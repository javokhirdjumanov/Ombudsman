using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StateProgramController : ControllerBase
{
    private readonly IStateProgramService stateProgramService;
    public StateProgramController(IStateProgramService stateProgramService)
    {
        this.stateProgramService = stateProgramService;
    }
    [HttpPost]
    public async ValueTask<ActionResult<SPDto>> CreateAsync(SPDlDto spDlDto)
    {
        var newStateProgram = await this.stateProgramService
            .CreateStateProgramAsync(spDlDto);

        return Created("", newStateProgram);
    }
    [HttpGet]
    public async ValueTask<ActionResult<SPDto>> SelectByIdAsync(int id)
    {
        var sps = await this.stateProgramService
            .SelectByIdAsync(id);

        return Ok(sps);
    }
    [HttpPut]
    public async ValueTask<ActionResult<SPDto>> UpdateAsync(SPModifyDlDto dto)
    {
        var sps = await this.stateProgramService
            .UpdateAsync(dto);

        return Ok(sps);
    }
    [HttpGet]
    public IActionResult SelectListAsync()
    {
        var statePrograms = this.stateProgramService
            .StateProgramSelectList();

        return Ok(statePrograms);
    }
    [HttpDelete("{id:int}")]
    public async ValueTask<ActionResult<SPDto>> DeleteAsync(int id)
    {
        var removedStateProgram = await this.stateProgramService.DeleteStateProgramAsync(id);

        return Ok(removedStateProgram);
    }
}
