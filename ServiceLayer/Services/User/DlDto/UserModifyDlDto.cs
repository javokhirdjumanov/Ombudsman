using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class UserModifyDlDto : UserDlDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}