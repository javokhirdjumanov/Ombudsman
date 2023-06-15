using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumPerformerType
    {
        public EnumPerformerType()
        {
            EnumPerformerTypeTranslates = new HashSet<EnumPerformerTypeTranslate>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int OrderNumber { get; set; }
        public string? ShortName { get; set; }
        public string? FullName { get; set; }

        public virtual EnumStatus Status { get; set; } = null!;
        public virtual ICollection<EnumPerformerTypeTranslate> EnumPerformerTypeTranslates { get; set; }
    }
}
