using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class BaseInfLetterDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int informationLetterNumber { get; set; }

    [Required]
    public string visaHolder { get; set; }

    [Required]
    public string informationLetterText { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int stateProgramId { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int employeeId { get; set; }

    [Required]
    public string ResponsibleEmployee { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}
