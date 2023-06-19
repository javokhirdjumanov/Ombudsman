namespace ServiceLayer.Services;
public class InformationLetterDto
{
    public int Id { get; set; }
    public int InformationLetterNumber { get; set; }
    public DateTime InformationLetterDate { get; set; }
    public string VisaHolder { get; set; }
    public string InformationLetterText { get; set; }
    public SPDto stateProgram { get; set; }
    public EmpDto employee { get; set; }
    public string ResponsibleEmployee { get; set; }
    public string PhoneNumber { get; set; }
    public int DocumentId { get; set; }
}
