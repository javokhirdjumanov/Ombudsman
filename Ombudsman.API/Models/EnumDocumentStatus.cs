using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumDocumentStatus
    {
        public EnumDocumentStatus()
        {
            DocDocuments = new HashSet<DocDocument>();
            EnumDocumentStatusTranslates = new HashSet<EnumDocumentStatusTranslate>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int OrderNumber { get; set; }
        public string? ShortName { get; set; }
        public string? FullName { get; set; }

        public virtual EnumStatus Status { get; set; } = null!;
        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<EnumDocumentStatusTranslate> EnumDocumentStatusTranslates { get; set; }
    }
}
