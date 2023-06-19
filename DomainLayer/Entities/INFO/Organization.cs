using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.HL;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table(TableNames.Organization)]
[Index("OrganizationId", Name = "ix_info_organization_organization_id")]
[Index("StateId", Name = "ix_info_organization_state_id")]
[Index("StateOrganizationIds", Name = "ix_info_organization_state_organization_ids")]
public class Organization 
{
    public Organization()
    {
        Documents = new HashSet<Document>();
        VisaHolders = new HashSet<VisaHolders>();
        Employees = new HashSet<Employee>();
        Users = new HashSet<User>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("state_organization_ids")]
    public int StateOrganizationIds { get; set; }
    [Column("is_grouper")]
    public bool IsGrouper { get; set; }
    [Column("organization_id")]
    public int? OrganizationId { get; set; }
    [Column("state_id")]
    public int StateId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("short_name")]
    public string? ShortName { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }

    [ForeignKey("OrganizationId")]
    public virtual Organization? SuperiorOrganization { get; set; }
    [ForeignKey("StateId")]
    [InverseProperty("Organizations")]
    public virtual State State { get; set; } = null!;
    [ForeignKey("StateOrganizationIds")]
    [InverseProperty("Organizations")]
    public virtual StateOrganization StateOrganizationIdsNavigation { get; set; } = null!;
    [InverseProperty("Organization")]
    public virtual ICollection<Document> Documents { get; set; }
    [InverseProperty("Organization")]
    public virtual ICollection<VisaHolders> VisaHolders { get; set; }
    [InverseProperty("Organization")]
    public virtual ICollection<Employee> Employees { get; set; }
    [InverseProperty("Organization")]
    public virtual ICollection<User> Users { get; set; }
}
