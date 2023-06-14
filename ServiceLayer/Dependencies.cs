using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

namespace ServiceLayer;
public static class Dependencies
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();

        services.AddScoped<IAuthServices, AuthServices>();

        return services;
    }
}
