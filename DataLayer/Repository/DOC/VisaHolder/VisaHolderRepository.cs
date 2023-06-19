using DataLayer.Context;
using DomainLayer.Entities.DOC;

namespace DataLayer.Repository;
public class VisaHolderRepository : BaseRepository<VisaHolders, int>, IVisaHolderRepository
{
    public VisaHolderRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    {
    }
}
