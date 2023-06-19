using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Services;

public class UpdateVizaDlDto : BaseVizaDlDto
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
}
