using DataLayer.Auth;
using DataLayer.Context;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer;
public static class Dependencies
{
    public static IServiceCollection AddDataLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            string connectionString = configuration
                .GetConnectionString("DefaultConnectionString");

            options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
        });

        AddRepositories(services);

        return services;
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileRepository, FileRepository>();

        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();

        services.AddScoped<IDocumentRepository, DocumentRepository>();

        services.AddScoped<IUserRepository, UserRepositories>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        services.AddScoped<IOrganizationRepository, OrganizationRepository>();

        services.AddScoped<ISectorRepository, SectorRepository>();

        services.AddScoped<IStateProgramRepository, StateProgramRepository>();

        services.AddScoped<IInformationLetterRepository, InformationLetterRepository>();
        
        services.AddScoped<IVisaHolderRepository, VisaHolderRepository>();
    }
}
