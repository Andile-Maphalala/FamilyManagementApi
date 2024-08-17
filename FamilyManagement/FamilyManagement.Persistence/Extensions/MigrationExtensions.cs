using FamilyManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FamilyManagement.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<FamilyManagementDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
