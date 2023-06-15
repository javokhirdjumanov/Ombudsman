using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumStatusTranslate
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int LanguageId { get; set; }
        public string ColumnName { get; set; } = null!;
        public string TranslateText { get; set; } = null!;

        public virtual EnumLanguage Language { get; set; } = null!;
        public virtual EnumStatus Status { get; set; } = null!;
    }
}
