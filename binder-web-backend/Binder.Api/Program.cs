using Binder.Api.Constants;
using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Binder.Application.Services.Middleware;
using Binder.Persistence.Configurations;
using Binder.Persistence.Models.Interfaces;
using Binder.Persistence.Repositories;
using Microsoft.OpenApi.Models;

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

            builder.Services.AddScoped<IDefaultTableRepository, DefaultTableRepository>();
            builder.Services.AddScoped<IDefaultTableService, DefaultTableService>();

            string backendUrl = builder.Configuration
                .GetSection(WebApiIocConfigValues.BackendUrlSectionKey).Value!;

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(WebApiIocConfigValues.ApiDocsVersion, new OpenApiInfo
                {
                    Version = WebApiIocConfigValues.ApiDocsVersion,
                    Title = WebApiIocConfigValues.ApiDocsTitle,
                    Description = WebApiIocConfigValues.ApiDocsDescription,
                });

                options.AddServer(new OpenApiServer
                {
                    Url = backendUrl
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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