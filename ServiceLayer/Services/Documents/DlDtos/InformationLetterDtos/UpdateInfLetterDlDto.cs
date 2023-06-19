using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class UpdateInfLetterDlDto : BaseInfLetterDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
}
