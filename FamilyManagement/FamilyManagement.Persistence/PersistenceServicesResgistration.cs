using Microsoft.Extensions.Configuration;
using FamilyManagement.Persistence.Data;
using FamilyManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FamilyManagement.Services.Repositories;

namespace FamilyManagement.Persistence
{
    public static partial class PersistenceServicesResgistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, Action<DbContextOptionsBuilder> configureContext)
        {
            services.AddDbContext<FamilyManagementDbContext>(configureContext);
            services.AddScoped<IFamilyManagementRepository, FamilyManagementRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static Action<DbContextOptionsBuilder> ConfigureDbContext(string connectionstring)
        {
            return (DbContextOptionsBuilder options) =>
            {
                options.UseNpgsql(connectionstring,
            b => b.MigrationsAssembly("FamilyManagement.Persistence"));
            };
        }
    }
}
