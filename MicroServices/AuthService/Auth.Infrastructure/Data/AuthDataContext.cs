using Auth.Domain.Models;
using Auth.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Data;
public class AuthDataContext : IdentityDbContext<AppUser>
{
    public AuthDataContext(DbContextOptions<AuthDataContext> options) : base(options)
    {
        var pendingMigrations = Database.GetPendingMigrations();
        if (pendingMigrations.Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseOracleDisableQuoting();
    }
}