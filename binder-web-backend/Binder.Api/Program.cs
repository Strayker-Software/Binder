using Binder.Api.Constants;
using Binder.Api.Extensions;
using Binder.Application.Extensions;
using Binder.Application.Services.Middleware;
using Binder.Persistence.Configurations;
using Binder.Persistence.Extensions;

namespace Binder.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
           var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMySqlConfig(builder.Configuration);
            builder.Services.AddServices();
            builder.Services.AddRepositories();
            builder.Services.AddSwaggerDocumentation(args);

            var app = builder.Build();

            app.UseSwaggerDocumentation();
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