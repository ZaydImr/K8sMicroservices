using Auth.Domain.Models;
using Auth.Infrastructure.Data;

namespace Auth.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddAuthorization();
        services
            .AddIdentityApiEndpoints<AppUser>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<AuthDataContext>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

}
