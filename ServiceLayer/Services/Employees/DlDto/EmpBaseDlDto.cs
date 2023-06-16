using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class EmpBaseDlDto
{
    [Required, MaxLength(100)]
    public string fio { get; set; }
    [Required, MaxLength(100)]
    public string phonenumber { get; set; }
    [Required, Range(1, double.MaxValue)]
    public double salary { get; set; }
    [Required, MaxLength(100)]
    public string email { get; set; }
}
