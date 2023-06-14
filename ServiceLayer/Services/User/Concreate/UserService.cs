using DataLayer.Context;
using DataLayer.Repository;
using DomainLayer.Entities.HL;
using ServiceLayer.Extantions;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class UserService : IUserService
{
    private readonly ApplicationDbContext context;
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;
    public UserService(
        ApplicationDbContext context,
        IUserRepository userRepository,
        IUserFactory userFactory)
    {
        this.context = context;
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }

    public async ValueTask<UserDto> CreateUserAsync(UserDlDto userCreationDlDto)
    {
        var newUser = this.userFactory
            .MapToUser(userCreationDlDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return this.userFactory
            .MapToUserDto(addedUser);
    }

    public IQueryable<UserDto> RetrieveUsers()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(int userId)
    {
       throw new Exception();
    }
    
    public ValueTask<UserDto> ModifyUserAsync(UserModifyDlDto userModifyDlDto)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<UserDto> RemoveUserAsync(int userId)
    {
        userId.IsDefault();

        var storageUser = await this.userRepository
            .SelectByIdAsync(userId);

        ValidationStorageObj
            .GenericValidation<User>(storageUser, userId);

        var removeUser = await this.userRepository
            .DeleteAsync(storageUser);

        return this.userFactory
            .MapToUserDto(removeUser);
    }
}