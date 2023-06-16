using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using AutoMapper;

namespace ServiceLayer;
public static class Dependencies
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();

        services.AddScoped<IAuthServices, AuthServices>();

        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<IUserFactory, UserFactory>();

        services.AddScoped<IStateProgramService, StateProgramService>();

        services.AddScoped<ISectorService, SectorService>();

        services.AddScoped<IManualService, ManualService>();

        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IFactoryOrganization, FactoryOrganization>();

        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
