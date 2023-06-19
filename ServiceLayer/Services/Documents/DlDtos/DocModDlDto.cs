using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services.Documents;
public class DocModDlDto : BaseDocDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }

    public UpdateInfLetterDlDto updateInfLetterDlDto { get; set; }
}
