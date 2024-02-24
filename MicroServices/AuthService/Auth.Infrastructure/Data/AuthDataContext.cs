using Auth.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Data;
public class AuthDataContext : IdentityDbContext
{
    public AuthDataContext(DbContextOptions<AuthDataContext> options) : base(options)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseOracleDisableQuoting();
    }
}