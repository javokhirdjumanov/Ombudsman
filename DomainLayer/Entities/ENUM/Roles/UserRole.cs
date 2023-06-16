using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table("enum_user_role", Schema = "public")]
public class UserRole
{
    public int Id { get; set; }
    public string Name { get; set; }
}
