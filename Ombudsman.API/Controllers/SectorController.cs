using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SectorController : ControllerBase
{
    private readonly ISectorService sertorService;
    public SectorController(ISectorService sertorService)
    {
        this.sertorService = sertorService;
    }
    [HttpPost]
    public async ValueTask<ActionResult<SectorDto>> PostSectorAsync(SectorDlDto sectorDlDto)
    {
        var newSector = await this.sertorService
            .CreateSectorAsync(sectorDlDto);

        return Created("", newSector);
    }

    [HttpGet("All")]
    public IActionResult GetAllSectors()
    {
        var sectors = this.sertorService.GetAllSectorsAsync();

        return Ok(sectors);
    }

    [HttpDelete("{id:int}")]
    public async ValueTask<ActionResult<SectorDto>> DeleteSectorAsync(int id)
    {
        var deleteSector = await this.sertorService
            .DeleteSectorAsync(id);

        return Ok(deleteSector);
    }
}
