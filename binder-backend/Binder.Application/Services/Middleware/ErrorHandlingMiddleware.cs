using System.Net;
using System.Text.Json;
using Binder.Application.Services.Middleware.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = e switch
            {
                InvalidOperationException invalidOperationException => new ProblemDetails
                {
                    Title = "Invalid operation!",
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = invalidOperationException.Message
                },
                NotFoundException notFoundException => new ProblemDetails
                {
                    Title = "Resource not found!",
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = notFoundException.Message
                },
                _ => new ProblemDetails
                {
                    Title = "An unexpected error occurred!",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = e.Message
                },
            };
            context.Response.ContentType = "application/problem+json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }
}
