using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class UserBaseDlDto
{
    [Required]
    [MaxLength(100)]
    public string FIO { get; set; }

    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int roleId { get; set; }
}
