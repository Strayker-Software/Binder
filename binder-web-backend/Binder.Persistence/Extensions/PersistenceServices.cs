using Binder.Persistence.Models.Interfaces;
using Binder.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Binder.Persistence.Extensions
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
            services.AddScoped<IDefaultTableRepository, DefaultTableRepository>();

            return services;
        }
    }
}