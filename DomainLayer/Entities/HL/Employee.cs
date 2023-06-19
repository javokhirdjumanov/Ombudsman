using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities;
[Table(TableNames.Employee, Schema = "public")]
[Index("OrganizationId", Name = "ix_hl_employee_organization_id")]
public class Employee
{
    public Employee()
    {
        InformationLetters = new HashSet<InformationLetter>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("fio")]
    public string Fio { get; set; } = null!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;
    [Column("salary")]
    public double Salary { get; set; }
    [Column("email")]
    public string Email { get; set; } = null!;
    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("Employees")]
    public virtual Organization Organization { get; set; } = null!;
    [InverseProperty("Employee")]
    public virtual ICollection<InformationLetter> InformationLetters { get; set; }
}
