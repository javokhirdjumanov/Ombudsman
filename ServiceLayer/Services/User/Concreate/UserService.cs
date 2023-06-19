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
        var entity = this.mapper.Map<User>(dto);
        entity.Salt = Guid.NewGuid().ToString();
        entity.PasswordHash = passwordHasher
            .Encrypt(dto.Password, entity.Salt);

        entity = await this.userRepository
            .InsertAsync(entity);

        return entity.Id;
    }
    public IQueryable<UserDto> SelectList()
    {
        var users = this.userRepository
            .SelectAll()
            .Include(x => x.Role)
            .Include(u => u.Organization);

        /*if (authServices.User.Role.Id != StatusIds.DELETE)
        {
            users = users
                .Where(u => u.OrganizationId == authServices.User.OrganizationId)
                .Include(x => x.Role);
        }*/
        users = users
            .Where(u => u.Role.Id != StatusIds.DELETE)
            .Include(x => x.Role)
            .Include(u => u.Organization);

        return users
            .Select(x => this.mapper.Map<UserDto>(x));
    }
    public async ValueTask<UserDto> SelectByIdAsync(int id)
    {
        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
            expression: u => u.Id == id && u.RoleId != StatusIds.DELETE,
            includes: new string[]
            { 
                nameof(User.Role)
            });

        ValidationStorageObj
            .GenericValidation<User>(storageUser, id);

        /*if (storageUser.OrganizationId == authServices.User.OrganizationId)
            return mapper.Map<UserDto>(storageUser);
        else
            throw new Exception($"User NotFound with given id: {id}");*/
        return mapper.Map<UserDto>(storageUser);
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

        user.RoleId = StatusIds.DELETE;

        await this.unitOfWork.Save();

        return user.Id;
    }
}