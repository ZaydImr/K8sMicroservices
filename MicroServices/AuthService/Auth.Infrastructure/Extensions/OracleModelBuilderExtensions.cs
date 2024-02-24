using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Extensions;

public static class OracleModelBuilderExtensions
{
    public static ModelBuilder UseOracleDisableQuoting(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToUpperInvariant()); // Optionally, you can force table names to be uppercase
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToUpperInvariant()); // Optionally, you can force column names to be uppercase
            }
        }
        return modelBuilder;
    }
}