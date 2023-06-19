using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class VisaController : ControllerBase
{
    private readonly IVisaHolderService visaHolderService;
    public VisaController(IVisaHolderService visaHolderService)
    {
        this.visaHolderService = visaHolderService;
    }

    [HttpGet]
    public IActionResult SelectList()
    {
        var visas = this.visaHolderService
            .SelectList();

        return Ok(visas);
    }
    [HttpGet]
    public async ValueTask<ActionResult<VizaHolderDto>> SelectById(int id)
    {
        var visa = await this.visaHolderService
            .SelectByIdAsync(id);

        return Ok(visa);
    }
    [HttpPut]
    public async ValueTask<ActionResult<VizaHolderDto>> UpdateAsync(UpdateVizaDlDto dto, int? docId, int? infId)
    {
        var visa = await this.visaHolderService
            .UpdateAsync(dto, docId, infId);

        return Ok(visa);
    }
    [HttpGet]
    public async ValueTask<ActionResult<VizaHolderDto>> DeleteAsync(int id, int? documentId, int? informationId)
    {
        var removed = await this.visaHolderService
            .DeleteAsync(id, documentId, informationId);

        return Ok(removed);
    }
}
