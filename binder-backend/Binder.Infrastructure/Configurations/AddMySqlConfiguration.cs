using Binder.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Binder.Infrastructure.Configurations
{
    public static class AddMySqlConfiguration
    {
        public static IServiceCollection AddMySqlConfig(this IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=binder_db;Uid=root;Pwd=;";
            var version = new MySqlServerVersion(new Version(10, 4, 27));
            services.AddDbContext<BinderDbContext>(contextOptions => contextOptions.UseMySql(connectionString, version));

            return services;
        }
    }
}