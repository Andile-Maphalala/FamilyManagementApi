using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FamilyManagement.Services
{
    public static class ApplicationServicesResgistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
