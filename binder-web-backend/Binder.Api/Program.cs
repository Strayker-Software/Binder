using Binder.Api.Constants;
using Binder.Api.Extensions;
using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Binder.Application.Services.Middleware;
using Binder.Persistence.Configurations;
using Binder.Persistence.Models.Interfaces;
using Binder.Persistence.Repositories;

namespace Binder.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMySqlConfig();

            builder.Services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
            builder.Services.AddScoped<IDefaultTableRepository, DefaultTableRepository>();
            builder.Services.AddScoped<IDefaultTableService, DefaultTableService>();
            builder.Services.AddScoped<IToDoTasksService, ToDoTasksService>();
            builder.Services.AddScoped<IAppVersionService, AppVersionService>();

            builder.Services.AddSwaggerDocumentation(args);

            var app = builder.Build();

            var env = app.Environment;
            app.UseSwaggerDocumentation(env);

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            string frontendUrl = builder.Configuration
                .GetSection(WebApiIocConfigValues.FrontendUrlSectionKey).Value!;

            app.UseCors(policy =>
            {
                policy.WithOrigins(frontendUrl);
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}