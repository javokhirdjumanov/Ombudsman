using DataLayer.Context;
using DomainLayer.Entities.DOC.Files;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository;
internal class FileRepository : IFileRepository
{
    private readonly ApplicationDbContext context;
    public FileRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async ValueTask<FileModel> CreateAsync(FileModel file)
    {
        var entityEntry = await context
            .AddAsync(file);

        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<FileModel> GetFileByIdAsync(int fileId)
    {
        return await context
            .Set<FileModel>()
            .FirstOrDefaultAsync(x => x.Id == fileId);
    }
}
