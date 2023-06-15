using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ServiceLayer.Services;
public class SectorDlDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int sector_number { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int status_id { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int order_number { get; set; }
    public string? short_name { get; set; }
    public string? full_name { get; set; }
}