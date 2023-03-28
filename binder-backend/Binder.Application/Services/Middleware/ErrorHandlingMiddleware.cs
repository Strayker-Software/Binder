using System.Net;
using System.Text.Json;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Application.Services.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private const string problemJsonType = "application/problem+json";

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
                        Title = ExceptionConstants.InvalidOperationTitle,
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = invalidOperationException.Message
                    },
                    NotFoundException notFoundException => new ProblemDetails
                    {
                        Title = ExceptionConstants.NotFoundTitle,
                        Status = (int)HttpStatusCode.NotFound,
                        Detail = notFoundException.Message
                    },
                    _ => new ProblemDetails
                    {
                        Title = ExceptionConstants.UnexpectedTitle,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = e.Message
                    },
                };
                context.Response.ContentType = problemJsonType;

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}