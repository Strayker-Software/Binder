using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Binder.Application.Services.Middleware;
using Binder.Infrastructure.Configurations;
using Binder.Infrastructure.Models.Interfaces;
using Binder.Infrastructure.Repositories;

namespace Binder.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMySqlConfig();

            builder.Services.AddScoped<ITestRepository, BaseEntitiesRepository>();
            builder.Services.AddScoped<ITestService, TestService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}