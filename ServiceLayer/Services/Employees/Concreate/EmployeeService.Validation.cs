using DomainLayer.Entities;

namespace ServiceLayer.Services;
public partial class EmployeeService
{
    public void ValidationIfPersonHisOrganization(int organizationId)
    {
        if (organizationId != this.authServices.User.OrganizationId)
        {
            throw new Exception("You have not permession that to view this user");
        }
    }
}
