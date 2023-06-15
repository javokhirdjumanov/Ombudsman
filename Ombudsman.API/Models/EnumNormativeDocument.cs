using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumNormativeDocument
    {
        public EnumNormativeDocument()
        {
            DocDocuments = new HashSet<DocDocument>();
            EnumNormativeDocumentTranslates = new HashSet<EnumNormativeDocumentTranslate>();
        }

        public int Id { get; set; }
        public string ShortCharacter { get; set; } = null!;
        public int StatusId { get; set; }
        public int OrderNumber { get; set; }
        public string? ShortName { get; set; }
        public string? FullName { get; set; }

        public virtual EnumStatus Status { get; set; } = null!;
        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<EnumNormativeDocumentTranslate> EnumNormativeDocumentTranslates { get; set; }
    }
}
