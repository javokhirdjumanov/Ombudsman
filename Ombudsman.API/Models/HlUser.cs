using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class HlUser
    {
        public HlUser()
        {
            DocDocuments = new HashSet<DocDocument>();
            DocInformationLetters = new HashSet<DocInformationLetter>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredDate { get; set; }
        public int OrganizationId { get; set; }
        public int LanguageId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual EnumLanguage Language { get; set; } = null!;
        public virtual InfoOrganization Organization { get; set; } = null!;
        public virtual EnumUserRole Role { get; set; } = null!;
        public virtual ICollection<DocDocument> DocDocuments { get; set; }
        public virtual ICollection<DocInformationLetter> DocInformationLetters { get; set; }
    }
}
