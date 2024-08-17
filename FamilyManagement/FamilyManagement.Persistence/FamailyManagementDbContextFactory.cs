using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FamilyManagement.Persistence.Data;

namespace FamilyManagement.Persistence
{
    public static partial class PersistenceServicesResgistration
    {
        public class FamailyManagementDbContextFactory : IDesignTimeDbContextFactory<FamilyManagementDbContext>
        {
            public FamilyManagementDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddUserSecrets("appsettings.json")
                    .AddUserSecrets<FamailyManagementDbContextFactory>()
                    .Build();

                var builder = new DbContextOptionsBuilder<FamilyManagementDbContext>();
                var connectionString = configuration.GetConnectionString("ConnectionString");

                builder.UseNpgsql(connectionString);

                return new FamilyManagementDbContext(builder.Options);
            }
        }
    }
}
