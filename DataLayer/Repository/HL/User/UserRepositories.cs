using DataLayer.Context;
using DomainLayer.Entities.HL;

namespace DataLayer.Repository;
public class UserRepositories 
    : BaseRepository<User, int>, IUserRepository
{
    public UserRepositories(ApplicationDbContext appDbContext) 
        : base(appDbContext)
    { }
}
