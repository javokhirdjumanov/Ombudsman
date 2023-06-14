using DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer;
public class UnitOfWork : IUnitOfWork
{
    public ApplicationDbContext context { get; set; }
    private readonly IServiceProvider serviceProvider;
    public UnitOfWork(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        this.context = context;
        this.serviceProvider = serviceProvider;
    }

    public IDbContextTransaction Transaction 
        => context.Database.CurrentTransaction;

    public TRepository GetRepository<TRepository>()
    {
        return this.serviceProvider.GetRequiredService<TRepository>();
    }

    public async Task Commit()
    {
        await this.context.Database.CommitTransactionAsync();
    }

    public async Task Rolback()
    {
        await this.context.Database.RollbackTransactionAsync();
    }

    public async Task Save()
    {
        await this.context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> TransactionAsync()
    {
        return await this.context.Database.BeginTransactionAsync();
    }
}
