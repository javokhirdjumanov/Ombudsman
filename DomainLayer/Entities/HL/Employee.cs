using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities;
[Table(TableNames.Employee, Schema = "public")]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FIO { get; set; }
    public string PhoneNumber { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public int OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public Organization Organization { get; set; }
}
