using Binder.Application.Models.Interfaces;
using Binder.Application.Services;
using Binder.Application.Services.Middleware;
using Binder.Infrastructure.Configurations;
using Binder.Infrastructure.Models.Interfaces;
using Binder.Infrastructure.Repositories;
using Microsoft.Net.Http.Headers;

namespace Binder.Api
{
    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMySqlConfig();

            builder.Services.AddScoped<IDefaultTableRepository, DefaultTableRepository>();
            builder.Services.AddScoped<IDefaultTableService, DefaultTableService>();

            builder.Services.AddCors(setup =>
            {
                setup.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                            .WithHeaders(HeaderNames.AccessControlAllowOrigin);
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}