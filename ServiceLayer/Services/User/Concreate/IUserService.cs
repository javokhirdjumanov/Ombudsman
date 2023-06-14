namespace ServiceLayer.Services;
public interface IUserService
{
    ValueTask<UserDto> CreateUserAsync(UserDlDto userCreationDlDto);
    IQueryable<UserDto> RetrieveUsers();
    ValueTask<UserDto> RetrieveUserByIdAsync(int userId);
    ValueTask<UserDto> ModifyUserAsync(UserModifyDlDto userModifyDlDto);
    ValueTask<UserDto> RemoveUserAsync(int userId);
}
