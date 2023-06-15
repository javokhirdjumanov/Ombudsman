using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class OrgDlDtoForModify : OrgDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
}
