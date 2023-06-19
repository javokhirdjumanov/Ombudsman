using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ServiceLayer.Services;
public class SectorDlDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int sectorNumber { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int stateId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int orderNumber { get; set; }
    public string? shortName { get; set; }
    public string? fullName { get; set; }
}