using DataLayer.Context;
using DataLayer.Repository;
using DomainLayer.Entities.DOC.Files;
using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DataTransferObjects;
using ServiceLayer.Extantions;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    public FileService(IFileRepository fileRepository)
    {
        this.fileRepository = fileRepository;
    }

    public async Task<(FileStream, FileModel)> DownloadFile(int fileId)
    {
        fileId.IsDefault();

        var storageFile = await this.fileRepository
            .GetFileByIdAsync(fileId);

        ValidationStorageObj
            .GenericValidation<FileModel>(storageFile, fileId);

        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Informations",
            "UploadsFiles",
            fileId.ToString() + storageFile.Type);

        if (!System.IO.File.Exists(filePath))
            throw new NotFoundException($"Couldn't file the given id: {filePath}");

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return (fileStream, storageFile);
    }

    public async Task<FileDto> UploadFile(IFormFile file)
    {
        var exension = Path.GetExtension(file.FileName);

        var newFile = await this.fileRepository.CreateAsync(new FileModel
        {
            Type = exension,
            FileName = file.FileName.Replace(exension, string.Empty),
        });

        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Informations",
            "UploadsFiles");

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        filePath = Path.Combine(filePath, newFile.Id.ToString() + newFile.Type);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return new FileDto(newFile.Id, newFile.Type, newFile.FileName);
    }
}
