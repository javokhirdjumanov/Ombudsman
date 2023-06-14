using DataLayer.Context;
using DomainLayer.Entities.DOC.Files;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.FileRepository;
internal class FileRepository : IFileRepository
{
    private readonly ApplicationDbContext context;
    public FileRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async ValueTask<FileModel> CreateAsync(FileModel file)
    {
        var entityEntry = await this.context
            .AddAsync<FileModel>(file);

        await this.context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<FileModel> GetFileByIdAsync(int fileId)
    {
        return await this.context
            .Set<FileModel>()
            .FirstOrDefaultAsync(x => x.Id == fileId);
    }
}
