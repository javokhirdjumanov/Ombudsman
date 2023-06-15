using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class EnumUserRole
    {
        public EnumUserRole()
        {
            HlUsers = new HashSet<HlUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<HlUser> HlUsers { get; set; }
    }
}
