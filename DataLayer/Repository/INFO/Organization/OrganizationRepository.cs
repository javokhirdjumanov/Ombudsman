using DataLayer.Context;
using DomainLayer.Entities.INFO;

namespace DataLayer.Repository;
public class OrganizationRepository : BaseRepository<Organization, int>, IOrganizationRepository
{
    public OrganizationRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    { }
}
