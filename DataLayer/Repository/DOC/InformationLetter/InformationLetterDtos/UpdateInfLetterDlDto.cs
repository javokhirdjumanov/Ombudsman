using System.ComponentModel.DataAnnotations;

namespace DataLayer.Repository.DOC.InformationLetter.InformationLetterDtos;
public class UpdateInfLetterDlDto : BaseInfLetterDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
}
