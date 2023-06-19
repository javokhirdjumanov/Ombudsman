using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class SPDlDto 
{
    [Required]
    [Range(1, int.MaxValue)]
    public int orderNumber { get; set; }
    public string? shortName { get; set; }
    public string? fullName { get; set; }
    [Required]
    [Range (1, int.MaxValue)]
    public int stateId { get; set; }
}
