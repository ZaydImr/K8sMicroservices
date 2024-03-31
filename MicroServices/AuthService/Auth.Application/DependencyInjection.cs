using Auth.Application.Mappers;
using Auth.Application.Services;
using Auth.Domain.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IAuthService, AuthService>();

        //Mappers
        services.AddScoped<UserMapper>();
        
        return services;
    }

}
