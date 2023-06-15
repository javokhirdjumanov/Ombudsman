using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

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

        return services;
    }
}
