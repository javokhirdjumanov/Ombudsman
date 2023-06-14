using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class UserDlDto
{
    [Required]
    [MaxLength(100)]
    public string FIO { get; set; }

    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength (100)]
    public string Email { get; set; }

    [Required]
    [MaxLength (255)]
    public string Password { get; set; }

    [Required]
    [Range (0, int.MaxValue)]
    public int roleId { get; set; }

    public int? organizationId { get; set; }
}
