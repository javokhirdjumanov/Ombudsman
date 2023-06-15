using DataLayer.Auth;
using DomainLayer.Entities.HL;

namespace ServiceLayer.Services;
public class UserFactory : IUserFactory
{
    private readonly IPasswordHasher passwordHasher;
    public UserFactory(IPasswordHasher passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }

    /// <summary>
    /// USER MODELI YASASH DB GA SAQLASH UCHUN
    /// </summary>
    public User MapToUser(UserDlDto userDlDto)
    {
        throw new NotImplementedException();

        var randomSalt = Guid.NewGuid().ToString();

        return new User
        {
            FIO = userDlDto.FIO,
            PhoneNumber = userDlDto.PhoneNumber,
            Email = userDlDto.Email,
            PasswordHash = this.passwordHasher.Encrypt(
                password: userDlDto.Password,
                salt: randomSalt),
            Salt = randomSalt,
            
        };
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
