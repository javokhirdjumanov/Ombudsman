using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class BaseVizaDlDto
{
    [Required]
    public int orderNumber { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int organizationId { get; set; }

    [Required]
    public string fio { get; set; }

    [Required]
    public string position { get; set; }

    [Required]
    public string responsibleEmployee { get; set; }

    [Required]
    public string phoneNumber { get; set; }

    //[JsonConverter(typeof(DateTimeConverter))]
    public DateTime? dateVisaAddition { get; set; }
}
