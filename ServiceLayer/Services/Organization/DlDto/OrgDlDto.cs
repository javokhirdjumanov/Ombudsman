using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class OrgDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int order_number { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int state_organization_id { get; set; }

    [Required]
    public bool is_grouper { get; set; }

    public int organization_id { get; set; }
    public string? short_name { get; set; }
    public string? full_name { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int status_id { get; set; }
}
