using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Binder.Application.Services.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string problemJsonType = "application/problem+json";

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                ProblemDetails problemDetails = GetProblemDetailsByExceptionFactory.GetProblemDetails(e);
                context.Response.StatusCode = (int)problemDetails.Status!;
                context.Response.ContentType = problemJsonType;

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}