namespace ServiceLayer.Services;
public interface IUserService
{
    ValueTask<int> CreateAsync(UserCreateDlDto userCreationDlDto);
    IQueryable<UserDto> SelectList();
    ValueTask<UserDto> SelectByIdAsync(int id);
    ValueTask<UserDto> UpdateAsync(UserModifyDlDto userModifyDlDto);
    ValueTask<int> DeleteAsync(int id);
}
