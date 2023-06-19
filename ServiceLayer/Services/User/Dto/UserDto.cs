namespace ServiceLayer.Services;
public class UserDto
{
    public int id { get; set; }
    public string fio { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public UserRoleDto role { get; set; }
    public string organization { get; set; }
}
