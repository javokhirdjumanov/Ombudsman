using System.ComponentModel.DataAnnotations;
using DataLayer.Repository.DOC.InformationLetter.InformationLetterDtos;

namespace ServiceLayer.Services.Documents;
public class DocCreateDlDto : BaseDocDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int normativeDocumentId { get; set; }

    public DateTime? sendDocumentData { get; set; }

    public int? normativeDocNumber { get; set; }
    public DateTime? normativeDocDate { get; set; }

    public CreateInfLetterDlDto? createLetterDlDto { get; set; }
    public List<CreateVizaDlDto>? createVizaDlDto { get; set; }
}
