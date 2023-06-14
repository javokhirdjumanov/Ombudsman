using DomainLayer.Entities.DOC.Files;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Services;
public interface IFileService
{
    Task<FileDto> UploadFile(IFormFile file);
    Task<(FileStream, FileModel)> DownloadFile(int fileId);
}
