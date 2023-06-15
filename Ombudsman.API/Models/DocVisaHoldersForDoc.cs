using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class DocVisaHoldersForDoc
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int OrderNumber { get; set; }
        public int? InformationLetterId { get; set; }
        public int OrganizationId { get; set; }
        public string Fio { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string ResponsibleEmployee { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime DateVisaAddition { get; set; }

        public virtual DocDocument Document { get; set; } = null!;
        public virtual DocInformationLetter? InformationLetter { get; set; }
        public virtual InfoOrganization Organization { get; set; } = null!;
    }
}
