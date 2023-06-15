using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumInitiativeType
    {
        public EnumInitiativeType()
        {
            DocDocuments = new HashSet<DocDocument>();
            EnumInitiativeTypeTranslates = new HashSet<EnumInitiativeTypeTranslate>();
        }

        public int Id { get; set; }
        public string Names { get; set; } = null!;

        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<EnumInitiativeTypeTranslate> EnumInitiativeTypeTranslates { get; set; }
    }
}
