using DomainLayer.Entities.HL;

namespace ServiceLayer.Services;
public class UserFactory : IUserFactory
{
    /// <summary>
    /// USER MODELI YASASH DB GA SAQLASH UCHUN
    /// </summary>
    public User MapToUser(UserDlDto userDlDto)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// MODIFICATION MAPPING FUNCTION
    /// </summary>
    public void MapToUser(User storageUser, UserModifyDlDto userModifyDlDto)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// FRONTGA CHIQADIGAN MODEL YASASH
    /// </summary>
    public UserDto MapToUserDto(User user)
    {
        throw new NotImplementedException();
    }
}
