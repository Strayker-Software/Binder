using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Binder.Persistence.Models.Interfaces;
using Binder.Persistence.Repositories;

namespace Binder.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDefaultTableService, DefaultTableService>();
            services.AddScoped<IToDoTasksService, ToDoTasksService>();
            services.AddScoped<IAppVersionService, AppVersionService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
            services.AddScoped<IDefaultTableRepository, DefaultTableRepository>();

            return services;
        }
    }
}