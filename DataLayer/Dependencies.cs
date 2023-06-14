using DataLayer.Context;
using DataLayer.Repository;
using DataLayer.Repository.FileRepository;
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

            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        AddRepositories(services);

        return services;
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileRepository, FileRepository>();
    }
}
