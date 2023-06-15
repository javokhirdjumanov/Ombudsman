using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumNormativeDocumentTranslate
    {
        public int Id { get; set; }
        public int NormativeDocumentTypeId { get; set; }
        public int LanguageId { get; set; }
        public string ColumnName { get; set; } = null!;
        public string TranslateText { get; set; } = null!;

        public virtual EnumLanguage Language { get; set; } = null!;
        public virtual EnumNormativeDocument NormativeDocumentType { get; set; } = null!;
    }
}
