using DataLayer.Auth;
using DataLayer.Context;
using DataLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DataLayer;
public static class Dependencies
{
    public static IServiceCollection AddDataLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication();

        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            string connectionString = configuration
                .GetConnectionString("DefaultConnectionString");

            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        AddAuth(services, configuration);

        AddRepositories(services);

        return services;
    }
    public static void AddAuth(IServiceCollection services, IConfiguration configuration)
    {
        /*services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy", options =>
            {
                options.RequireRole();
            });
        });*/

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileRepository, FileRepository>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();
    }
}
