using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class SectorController : ControllerBase
{
    private readonly ISectorService sertorService;
    public SectorController(ISectorService sertorService)
    {
        this.sertorService = sertorService;
    }
    [HttpPost]
    public async ValueTask<ActionResult<SectorDto>> CreateAsync(SectorDlDto sectorDlDto)
    {
        var newSector = await this.sertorService
            .CreateSectorAsync(sectorDlDto);

        return Created("", newSector);
    }
    [HttpGet]
    public IActionResult SelectList()
    {
        var sectors = this.sertorService.SectorsSelectListAsync();

        return Ok(sectors);
    }
    [HttpGet("{id:int}")]
    public async ValueTask<ActionResult<SectorDto>> SelectByIdAsync(int id)
    {
        var sectors = await this.sertorService
            .SelectSectorByIdAsync(id);

        return Ok(sectors);
    }
    [HttpPut]
    public IActionResult UpdateAsync(SectorUpdateDlDto sectorUpdateDlDto)
    {
        var sectors = this.sertorService
            .UpdateSectorAsync(sectorUpdateDlDto);

        return Ok(sectors);
    }
    [HttpDelete("{id:int}")]
    public async ValueTask<ActionResult<SectorDto>> DeleteAsync(int id)
    {
        var deleteSector = await this.sertorService
            .DeleteSectorAsync(id);

        return Ok(deleteSector);
    }
}
