using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;
public class CreateVizaDlDto : BaseVizaDlDto
{
    public int? documentId { get; set; }
    public int? informationLetterId { get; set; }
}

