namespace ServiceLayer.Services;
public class VizaHolderDto
{
    public int Id { get; set; }
    public int documentId { get; set; }
    public int orderNumber { get; set; }
    public int? informationLetterId { get; set; }
    public int organizationId { get; set; }
    public string fio { get; set; }
    public string position { get; set; }
    public string responsibleEmployee { get; set; }
    public string phoneNumber { get; set; }
    public DateTime createAt { get; set; }
    public DateTime dateVisaAddition { get; set; }
}
