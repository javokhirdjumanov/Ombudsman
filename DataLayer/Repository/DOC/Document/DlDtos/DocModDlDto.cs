using System.ComponentModel.DataAnnotations;
using DataLayer.Repository.DOC.InformationLetter.InformationLetterDtos;

namespace ServiceLayer.Services.Documents;
public class DocModDlDto : BaseDocDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }

    public UpdateInfLetterDlDto updateInfLetterDlDto { get; set; }
}
