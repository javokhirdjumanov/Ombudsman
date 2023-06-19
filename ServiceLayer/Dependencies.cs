using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

namespace ServiceLayer;
public static class Dependencies
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IDocumentService, DocumentService>();

        services.AddScoped<IVisaHolderService, VisaHolderService>();

        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddScoped<IOrganizationService, OrganizationService>();

        services.AddScoped<ISectorService, SectorService>();

        services.AddScoped<IStateProgramService, StateProgramService>();

        services.AddScoped<IManualService, ManualService>();

        services.AddScoped<IFileService, FileService>();

        services.AddScoped<IAuthServices, AuthServices>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
