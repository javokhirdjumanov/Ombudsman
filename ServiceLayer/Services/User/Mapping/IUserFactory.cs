using DomainLayer.Entities.HL;

namespace ServiceLayer.Services;
public interface IUserFactory
{
    UserDto MapToUserDto(User user);
    User MapToUser(UserDlDto userDlDto);
    void MapToUser(User storageUser, UserModifyDlDto userModifyDlDto);
}
