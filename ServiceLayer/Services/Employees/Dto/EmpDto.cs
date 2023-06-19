using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public class EmpDto
{
    public int Id { get; set; }
    public string FIO { get; set; }
    public string PhoneNumber { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public OrgDto? Organization { get; set; }
}
