using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Binder.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDefaultTableService, DefaultTableService>();
            services.AddScoped<IToDoTasksService, ToDoTasksService>();
            services.AddScoped<IAppVersionService, AppVersionService>();

            return services;
        }
    }
}