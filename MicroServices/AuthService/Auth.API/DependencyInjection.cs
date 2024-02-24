using Microsoft.AspNetCore.Identity;

namespace Auth.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddAuthorization();
        //services.AddIdentityApiEndpoints<IdentityUser>()


        return services;
    }

}
