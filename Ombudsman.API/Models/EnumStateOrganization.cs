using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumStateOrganization
    {
        public EnumStateOrganization()
        {
            EnumStateOrganizationTranslates = new HashSet<EnumStateOrganizationTranslate>();
            InfoOrganizations = new HashSet<InfoOrganization>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int OrderNumber { get; set; }
        public string? ShortName { get; set; }
        public string? FullName { get; set; }

        public virtual EnumStatus Status { get; set; } = null!;
        public virtual ICollection<EnumStateOrganizationTranslate> EnumStateOrganizationTranslates { get; set; }
        public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; }
    }
}
