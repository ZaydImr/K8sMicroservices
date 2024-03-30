using Auth.Application.IRepositories;
using Auth.Infrastructure.Data;
using Auth.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthDataContext>(opt => 
                                                    opt.UseOracle(configuration.GetConnectionString("StaffingDB"),
                                                    opt => 
                                                    {
                                                        opt.MigrationsAssembly("Auth.Infrastructure");
                                                    }));

        return services;
    }

}
