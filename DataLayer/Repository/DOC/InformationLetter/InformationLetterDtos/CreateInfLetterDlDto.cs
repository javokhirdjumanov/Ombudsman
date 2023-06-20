using System.ComponentModel.DataAnnotations;
using ServiceLayer.Services;

namespace DataLayer.Repository.DOC.InformationLetter.InformationLetterDtos;
public class CreateInfLetterDlDto : BaseInfLetterDlDto
{
    public List<CreateVizaDlDto>? createVizaDlDto { get; set; }
}
