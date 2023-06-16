using DataLayer.Context;
using DomainLayer.Entities;

namespace DataLayer.Repository;
public class EmployeeRepository : BaseRepository<Employee, int>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext appDbContext) 
        : base(appDbContext)
    { }
}
