using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class InfoOrganization
    {
        public InfoOrganization()
        {
            DocDocuments = new HashSet<DocDocument>();
            DocVisaHoldersForDocs = new HashSet<DocVisaHoldersForDoc>();
            HlUsers = new HashSet<HlUser>();
            InverseOrganization = new HashSet<InfoOrganization>();
        }

        public int Id { get; set; }
        public int StateOrganizationId { get; set; }
        public bool IsGrouper { get; set; }
        public int OrganizationId { get; set; }
        public int StatusId { get; set; }
        public int OrderNumber { get; set; }
        public string? ShortName { get; set; }
        public string? FullName { get; set; }

        public virtual InfoOrganization Organization { get; set; } = null!;
        public virtual EnumStateOrganization StateOrganization { get; set; } = null!;
        public virtual EnumStatus Status { get; set; } = null!;
        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<DocVisaHoldersForDoc> DocVisaHoldersForDocs { get; set; }
        public virtual ICollection<HlUser> HlUsers { get; set; }
        public virtual ICollection<InfoOrganization> InverseOrganization { get; set; }
    }
}
