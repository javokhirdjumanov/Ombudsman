using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumStatus
    {
        public EnumStatus()
        {
            EnumDocumentStatuses = new HashSet<EnumDocumentStatus>();
            EnumNormativeDocuments = new HashSet<EnumNormativeDocument>();
            EnumPerformerTypes = new HashSet<EnumPerformerType>();
            EnumStateOrganizations = new HashSet<EnumStateOrganization>();
            EnumStatusTranslates = new HashSet<EnumStatusTranslate>();
            InfoDocumentImportances = new HashSet<InfoDocumentImportance>();
            InfoOrganizations = new HashSet<InfoOrganization>();
            InfoSectors = new HashSet<InfoSector>();
            InfoStatePrograms = new HashSet<InfoStateProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EnumDocumentStatus> EnumDocumentStatuses { get; set; }
        public virtual ICollection<EnumNormativeDocument> EnumNormativeDocuments { get; set; }
        public virtual ICollection<EnumPerformerType> EnumPerformerTypes { get; set; }
        public virtual ICollection<EnumStateOrganization> EnumStateOrganizations { get; set; }
        public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; }
        public virtual ICollection<InfoDocumentImportance> InfoDocumentImportances { get; set; }
        public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; }
        public virtual ICollection<InfoSector> InfoSectors { get; set; }
        public virtual ICollection<InfoStateProgram> InfoStatePrograms { get; set; }
    }
}
