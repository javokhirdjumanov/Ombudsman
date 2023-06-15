using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class DocInformationLetter
    {
        public DocInformationLetter()
        {
            DocDocuments = new HashSet<DocDocument>();
            DocVisaHoldersForDocs = new HashSet<DocVisaHoldersForDoc>();
        }

        public int Id { get; set; }
        public int InformationLetterNumber { get; set; }
        public DateTime InformationLetterDate { get; set; }
        public string InformationLetterText { get; set; } = null!;
        public int StateProgramId { get; set; }
        public string VisaHolder { get; set; } = null!;
        public string ResponsibleEmployee { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual HlUser Employee { get; set; } = null!;
        public virtual InfoStateProgram StateProgram { get; set; } = null!;
        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<DocVisaHoldersForDoc> DocVisaHoldersForDocs { get; set; }
    }
}
