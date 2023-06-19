using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.HL;
[Table(TableNames.User, Schema = "public")]
[Index("LanguageId", Name = "ix_hl_user_language_id")]
[Index("OrganizationId", Name = "ix_hl_user_organization_id")]
[Index("RoleId", Name = "ix_hl_user_role_id")]
public class User
{
    private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;
    
    public User()
    {
        Documents = new HashSet<Document>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("fio")]
    public string Fio { get; set; } = null!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;
    [Column("email")]
    public string Email { get; set; } = null!;
    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;
    [Column("salt")]
    public string Salt { get; set; } = null!;
    [Column("refresh_token")]
    public string? RefreshToken { get; set; }
    [Column("refresh_token_expired_date", TypeName = "timestamp without time zone")]
    public DateTime? RefreshTokenExpiredDate { get; set; }
    [Column("organization_id")]
    public int? OrganizationId { get; set; }
    [Column("language_id")]
    public int LanguageId { get; set; } = 3;
    [Column("role_id")]
    public int RoleId { get; set; }
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    [ForeignKey("LanguageId")]
    [InverseProperty("Users")]
    public virtual Language Language { get; set; } = null!;
    [ForeignKey("OrganizationId")]
    [InverseProperty("Users")]
    public virtual Organization? Organization { get; set; }
    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual UserRole Role { get; set; } = null!;
    [InverseProperty("OrginizationUser")]
    public virtual ICollection<Document> Documents { get; set; }

    public void UpdateRefreshToken(string refreshToken, int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpiredDate = DateTime.Now.AddMinutes(expireDateInMinutes);
    }
}
