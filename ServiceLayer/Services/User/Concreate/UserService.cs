using AutoMapper;
using DataLayer;
using DataLayer.Auth;
using DataLayer.Repository;
using DomainLayer.Constants;
using DomainLayer.Entities.HL;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPasswordHasher passwordHasher;
    private readonly IMapper mapper;
    private readonly IAuthServices authServices;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork,
        IAuthServices authServices)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.passwordHasher = passwordHasher;
        this.unitOfWork = unitOfWork;
        this.authServices = authServices;
    }

    public async ValueTask<int> CreateAsync(UserCreateDlDto dto)
    {
        var newUSer = this.mapper.Map<User>(dto);

        newUSer.Salt = Guid.NewGuid().ToString();

        newUSer.PasswordHash = passwordHasher
            .Encrypt(dto.Password, newUSer.Salt);

        newUSer = await this.userRepository
            .InsertAsync(newUSer);

        return newUSer.Id;
    }
    public IQueryable<UserDto> SelectList()
    {
        var users = this.userRepository.SelectAll()
            .Include(x => x.Role).Include(u => u.Organization);
        if(authServices.User.RoleId != RoleConst.SUPERADMIN)
        {
            users = users
                .Where(u => u.OrganizationId == authServices.User.OrganizationId)
                .Include(u => u.Role)
                .Include(u => u.Organization);
        }

        return users
            .Select(x => this.mapper.Map<UserDto>(x));
    }
    public async ValueTask<UserDto> SelectByIdAsync(int id)
    {
        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
            expression: u => u.Id == id,
            includes: new string[]
            {
                nameof(User.Role)
            });

        ValidationStorageObj
            .GenericValidation<User>(storageUser, id);

        if (storageUser.OrganizationId == authServices.User.OrganizationId)
            return mapper.Map<UserDto>(storageUser);
        else
            throw new Exception($"User NotFound with given id: {id}");
    }
    public async ValueTask<UserDto> UpdateAsync(UserModifyDlDto dto)
    {
        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
            expression: u => u.Id == dto.Id,
            includes: new string[]
            {
                nameof(User.Role)
            });

        ValidationStorageObj
            .GenericValidation<User>(storageUser, dto.Id);

        if(storageUser.OrganizationId != authServices.User.OrganizationId)
            throw new Exception("You can only create visa holders for one model !");

        storageUser = this.mapper
            .Map(dto, storageUser);

        storageUser = await this.userRepository
            .UpdateAsync(storageUser);

        return this.mapper
            .Map<UserDto>(storageUser);
    }
    public async ValueTask<int> DeleteAsync(int id)
    {
        var user = await this.userRepository
            .SelectByIdAsync(id);

        user = await this.userRepository
            .DeleteAsync(user);

        return user.Id;
    }
}