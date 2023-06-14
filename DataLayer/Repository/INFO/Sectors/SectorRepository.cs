using DataLayer.Context;
using DomainLayer.Entities.INFO;

namespace DataLayer.Repository;
public class SectorRepository
    : BaseRepository<Sectors, int>, ISectorRepository
{
    public SectorRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    { }
}
