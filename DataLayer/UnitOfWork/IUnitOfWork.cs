using DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataLayer;
public interface IUnitOfWork
{
    ApplicationDbContext context { get; }
    IDbContextTransaction Transaction { get; }
    TRepository GetRepository<TRepository>();
    Task<IDbContextTransaction> TransactionAsync();
    Task Save();
    Task Commit();
    Task Rolback();
}
