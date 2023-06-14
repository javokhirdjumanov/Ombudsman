using DomainLayer.Entities.DOC.Files;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DataTransferObjects;

namespace ServiceLayer.Services;
public interface IFileService
{
    Task<FileDto> UploadFile(IFormFile file);
    Task<(FileStream, FileModel)> DownloadFile(int fileId);
}
