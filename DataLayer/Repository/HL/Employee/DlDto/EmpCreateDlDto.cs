using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class EmpCreateDlDto : EmpBaseDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int organizationId { get; set; }
}
