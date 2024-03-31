using Auth.API.Exceptions;
using Auth.Domain.Models;
using Auth.Infrastructure.Data;
using JwtConfiguration;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddAuthorization();
        services
            .AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<AuthDataContext>()
            .AddSignInManager()
            .AddRoles<IdentityRole>();

        services.AddEndpointsApiExplorer();

        services.AddJwtValidation(configuration);

        services
            .AddProblemDetails()
            .AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }

}
