using DomainLayer.Entities.HL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table("enum_user_role", Schema = "public")]
public class UserRole
{
    public UserRole()
    {
        Users = new HashSet<User>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; }
}
