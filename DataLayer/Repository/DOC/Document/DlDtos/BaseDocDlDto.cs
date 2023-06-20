using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class BaseDocDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int orderNumber { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int documentImportanceId { get; set; }

    public bool stateProgramIncluded { get; set; }

    public int? stateProgramId { get; set; }

    public string? documentName { get; set; }

    public string? documentContent { get; set;}

    public DateTime? estimatedExecutionTime { get; set; }

    public int? sectorId { get; set; }

    public string? mainMinistry { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int orginizationUserId { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int initiativeTypeId { get; set; }

    [Required, MaxLength(100)]
    public string performers { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int organizationId { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int documentStatusId { get; set; }

    public int? fileId { get; set; }
}
