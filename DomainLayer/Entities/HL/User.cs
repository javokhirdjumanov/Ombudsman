using DomainLayer.Constants;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.HL;
[Table(TableNames.User, Schema = "public")]
public class User
{
    private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;

    [Key]
    public int Id { get; set; }
    public string FIO { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string? RefreshToken { get; private set; }
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? RefreshTokenExpiredDate { get; private set; }

    public int? OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public Organization Organizations { get; set; }

    public int LanguageId { get; set; } = 1;
    [ForeignKey(nameof(LanguageId))]
    public Language Languages { get; set; }

    public int RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public UserRole Role { get; set; }
    [Column(TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    public void UpdateRefreshToken(string refreshToken, int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpiredDate = DateTime.UtcNow.AddMinutes(expireDateInMinutes);
    }
}
