using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumLanguage
    {
        public EnumLanguage()
        {
            EnumDocumentStatusTranslates = new HashSet<EnumDocumentStatusTranslate>();
            EnumInitiativeTypeTranslates = new HashSet<EnumInitiativeTypeTranslate>();
            EnumNormativeDocumentTranslates = new HashSet<EnumNormativeDocumentTranslate>();
            EnumPerformerTypeTranslates = new HashSet<EnumPerformerTypeTranslate>();
            EnumStateOrganizationTranslates = new HashSet<EnumStateOrganizationTranslate>();
            EnumStatusTranslates = new HashSet<EnumStatusTranslate>();
            HlUsers = new HashSet<HlUser>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public virtual ICollection<EnumDocumentStatusTranslate> EnumDocumentStatusTranslates { get; set; }
        public virtual ICollection<EnumInitiativeTypeTranslate> EnumInitiativeTypeTranslates { get; set; }
        public virtual ICollection<EnumNormativeDocumentTranslate> EnumNormativeDocumentTranslates { get; set; }
        public virtual ICollection<EnumPerformerTypeTranslate> EnumPerformerTypeTranslates { get; set; }
        public virtual ICollection<EnumStateOrganizationTranslate> EnumStateOrganizationTranslates { get; set; }
        public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; }
        public virtual ICollection<HlUser> HlUsers { get; set; }
    }
}
