using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class CreateInfLetterDlDto : BaseInfLetterDlDto
{
    public List<CreateVizaDlDto>? createVizaDlDto { get; set; }
}
