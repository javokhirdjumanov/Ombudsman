using DataLayer.Auth.JwtTokens;
using DataLayer.Repository;
using DomainLayer.Entities.HL;
using ServiceLayer.Services;

namespace Ombudsman.API.Middliwares;
public class UserInjectMiddlewares
{
    private readonly RequestDelegate _next;

    public UserInjectMiddlewares(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context,
        IAuthServices authService,
        IUserRepository repository)
    {
        var endpoint = context.GetEndpoint();
        var authorizeAttribute = endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>();

        if (authorizeAttribute != null)
        {
            string idClaim = (context.User.Claims.FirstOrDefault(c => c.Type == ClaimNames.Id)).Value;
            var user = await repository.SelectByIdWithDetailsAsync(
                expression: user => user.Id == int.Parse(idClaim),
                includes: new string[] { nameof(User.Role), nameof(User.Organization) });
            authService.User = user;

            // Invoke the UserMiddleware
            await _next.Invoke(context);
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}
