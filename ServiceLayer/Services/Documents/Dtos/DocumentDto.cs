using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Services;
public class DocumentDto
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public NormativeDocTypeDto? normativeDocument { get; set; }
    public DocumentImportanceDto? documentImportance { get; set; }
    public bool StateProgramIncluded { get; set; }
    public SPDto? stateProgram { get; set; }
    public string? DocumentName { get; set; }
    public string? DocumentContent { get; set; }
    public DateTime createAt { get; set; }
    public DateTime? sendDocumentData { get; set; }
    public DateTime? estimatedExecutionTime { get; set; }
    public SectorDto? sector { get; set; }
    public string? MainMinistry { get; set; }
    public InitiativeTypeDto? initiativeType { get; set; }
    public string performers { get; set; }
    public OrgDto? Organization { get; set; }
    public DocStatusDto? documentStatus { get; set; }
    public int? normativeDocNumber { get; set; }
    public DateTime? normativeDocDate { get; set; }
    public int? fileId { get; set; }

    public ICollection<InformationLetterDto>? informationLetters { get; set; }
    public ICollection<VizaHolderDto>? visaHolders { get; set; }
}
