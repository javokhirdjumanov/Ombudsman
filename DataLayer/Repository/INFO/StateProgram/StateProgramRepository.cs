using DataLayer.Context;
using DomainLayer.Entities.INFO;

namespace DataLayer.Repository;
public class StateProgramRepository : BaseRepository<StateProgram, int>, IStateProgramRepository
{
    public StateProgramRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    { }
}
