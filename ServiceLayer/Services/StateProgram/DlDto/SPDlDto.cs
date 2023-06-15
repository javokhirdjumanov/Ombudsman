using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class SPDlDto 
{
    [Required]
    [Range(1, int.MaxValue)]
    public int order_number { get; set; }
    public string? short_name { get; set; }
    public string? full_name { get; set; }
    [Required]
    [Range (1, int.MaxValue)]
    public int status_id { get; set; }
}
