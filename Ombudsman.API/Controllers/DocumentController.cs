using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using ServiceLayer.Services.Documents;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService documentService;
    public DocumentController(IDocumentService documentService)
    {
        this.documentService = documentService;
    }

    [HttpPost]
    [Authorize]
    public async ValueTask<ActionResult<int>> CreateAsync(DocCreateDlDto docCreateDlDto)
    {
        var documentId = await this.documentService
            .CreateAsync(docCreateDlDto);

        return Created("", documentId);
    }
    [HttpGet]
    public IActionResult SelectList()
    {
        var documents = this.documentService
            .SelectListAsync();

        return Ok(documents);
    }
    [HttpGet]
    public async ValueTask<ActionResult<DocumentDto>> SelectByIdAsync(int id)
    {
        var documents = await this.documentService
            .SelectByIdAsync(id);

        return Ok(documents);
    }
    [HttpPut]
    public async ValueTask<ActionResult<DocumentDto>> UpdateAsync(DocModDlDto docModDlDto)
    {
        var updatedDoc = await this.documentService
            .UpdateAsync(docModDlDto);

        return Ok(updatedDoc);
    }
    [HttpDelete]
    public async ValueTask<ActionResult<int>> DeleteAsync(int id)
    {
        var delete = await this.documentService
            .DeleteAsync(id);

        return Ok(delete);
    }
    [HttpGet]
    public async ValueTask<ActionResult<List<VizaHolderDto>>> SelectVisaViewerOfDocument(int documentId)
    {
        var doc = await this.documentService
            .VisaViewersOfDocument(documentId);

        return Ok(doc);
    }
    [HttpPost]
    public IActionResult FilteringDocumentsOfOrganizationByDatetime(
        int organizationId, DateOnly from_date, DateOnly to_date)
    {
        var documents = this.documentService
            .SelectDocumentByOrganization(organizationId, from_date, to_date);

        return Ok(documents);
    }
}
