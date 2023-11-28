using Binder.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binder.Persistence.Configurations
{
    public static class AddMySqlConfiguration
    {
        public static IServiceCollection AddMySqlConfig(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            var versionString = config["MySqlServerVersion"] ?? string.Empty;
            var version = new MySqlServerVersion(new Version(versionString));
            services.AddDbContext<BinderDbContext>(contextOptions => contextOptions.UseMySql(connectionString, version));

            return services;
        }
    }
}