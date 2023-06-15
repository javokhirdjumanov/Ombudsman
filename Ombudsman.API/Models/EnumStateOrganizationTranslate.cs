using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumStateOrganizationTranslate
    {
        public int Id { get; set; }
        public int StateOrganizationId { get; set; }
        public int LanguageId { get; set; }
        public string ColumnName { get; set; } = null!;
        public string TranslateText { get; set; } = null!;

        public virtual EnumLanguage Language { get; set; } = null!;
        public virtual EnumStateOrganization StateOrganization { get; set; } = null!;
    }
}
