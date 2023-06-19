using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class SPModifyDlDto : SPDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
}
