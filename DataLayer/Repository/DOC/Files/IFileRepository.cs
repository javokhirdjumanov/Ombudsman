using DomainLayer.Entities.DOC.Files;

namespace DataLayer.Repository;
public interface IFileRepository
{
    ValueTask<FileModel> CreateAsync(FileModel file);
    ValueTask<FileModel> GetFileByIdAsync(int fileId);
}
