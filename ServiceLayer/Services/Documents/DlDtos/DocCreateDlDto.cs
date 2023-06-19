using Newtonsoft.Json;
using ServiceLayer.ConverterFormat;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Services.Documents;
public class DocCreateDlDto : BaseDocDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int normativeDocumentId { get; set; }

    //[JsonConverter(typeof(DateTimeConverter))]
    public DateTime? sendDocumentData { get; set; }

    public int? normativeDocNumber { get; set; }
    public DateTime? normativeDocDate { get; set; }

    public CreateInfLetterDlDto? createLetterDlDto { get; set; }
    public List<CreateVizaDlDto>? createVizaDlDto { get; set; }
}
