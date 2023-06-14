using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IFileService fileServices;
    public FileController(IFileService fileServices)
    {
        this.fileServices = fileServices;
    }

    [HttpPost]
    public async Task<ActionResult<FileDto>> PostFile(IFormFile file)
    {
        var newFile = await this.fileServices.UploadFile(file);

        return Ok(newFile);
    }

    [HttpGet("{fileId:int}")]
    public async Task<IActionResult> DownloadFile(int fileId)
    {
        var (streamModel, model) = await this.fileServices.DownloadFile(fileId);

        return File(streamModel, "application/octet-stream", model.FileName + model.Type);
    }
}
