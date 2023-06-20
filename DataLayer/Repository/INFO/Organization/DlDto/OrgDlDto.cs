using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class OrgDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int orderNumber { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int stateOrganizationIds { get; set; }

    [Required]
    public bool isGrouper { get; set; }

    public int? organizationId { get; set; }
    public string? shortName { get; set; }
    public string? fullName { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int stateId { get; set; }
}
