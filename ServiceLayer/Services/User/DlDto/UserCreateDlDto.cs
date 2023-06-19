using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class UserCreateDlDto : UserBaseDlDto
{
    [Required]
    [MaxLength (255)]
    public string Password { get; set; }

    public int? organizationId { get; set; }
}
