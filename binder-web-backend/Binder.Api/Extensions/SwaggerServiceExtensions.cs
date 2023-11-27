using Binder.Api.Constants;
using Microsoft.OpenApi.Models;

namespace Binder.Api.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var backendUrl = builder.Configuration
                .GetSection(WebApiIocConfigValues.BackendUrlSectionKey).Value!;

            services.AddSwaggerGen(options =>
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

            return services;
        }        

        public static IApplicationBuilder UseSwaggerDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}