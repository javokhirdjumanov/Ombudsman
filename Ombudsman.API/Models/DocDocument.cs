using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class DocDocument
    {
        public DocDocument()
        {
            DocVisaHoldersForDocs = new HashSet<DocVisaHoldersForDoc>();
        }

        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int NormativeDocumentId { get; set; }
        public int DocumentImportanceId { get; set; }
        public bool StateProgramIncluded { get; set; }
        public int? StateProgramId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentContent { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? SendDocumentData { get; set; }
        public DateTime? EstimatedExecutionTime { get; set; }
        public int? SectorId { get; set; }
        public string? MainMinistry { get; set; }
        public int InitiativeTypeId { get; set; }
        public string Performers { get; set; } = null!;
        public int OrganizationId { get; set; }
        public int DocumentStatusId { get; set; }
        public int? NormativeDocNumber { get; set; }
        public DateTime? NormativeDocDate { get; set; }
        public int? InformationLetterId { get; set; }
        public int? FileId { get; set; }
        public int OrginizationUserId { get; set; }

        public virtual InfoDocumentImportance DocumentImportance { get; set; } = null!;
        public virtual EnumDocumentStatus DocumentStatus { get; set; } = null!;
        public virtual DocFileModel? File { get; set; }
        public virtual DocInformationLetter? InformationLetter { get; set; }
        public virtual EnumInitiativeType InitiativeType { get; set; } = null!;
        public virtual EnumNormativeDocument NormativeDocument { get; set; } = null!;
        public virtual InfoOrganization Organization { get; set; } = null!;
        public virtual HlUser OrginizationUser { get; set; } = null!;
        public virtual InfoSector? Sector { get; set; }
        public virtual InfoStateProgram? StateProgram { get; set; }
        public virtual ICollection<DocVisaHoldersForDoc> DocVisaHoldersForDocs { get; set; }
    }
}
