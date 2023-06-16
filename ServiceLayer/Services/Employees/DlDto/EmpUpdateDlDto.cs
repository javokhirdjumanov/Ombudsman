using ServiceLayer.Services;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Servicesl;
public class EmpUpdateDlDto : EmpBaseDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int id { get; set; }
}
