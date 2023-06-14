using DataLayer.Context;

namespace DataLayer.Repository;
public class StateProgram : BaseRepository<StateProgram, int>, IStateProgram
{
    public StateProgram(ApplicationDbContext appDbContext)
        : base(appDbContext)
    { }
}
