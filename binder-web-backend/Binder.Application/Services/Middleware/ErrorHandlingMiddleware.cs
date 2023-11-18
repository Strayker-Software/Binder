using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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
                ProblemDetails problemDetails = null;
                switch (e)
                {
                    case InvalidOperationException:
                        problemDetails = new ProblemDetails
                        {
                            Title = nameof(HttpStatusCode.BadRequest),
                            Status = (int)HttpStatusCode.BadRequest,
                            Detail = ExceptionConstants.InvalidOperationMessage,
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundException:
                        problemDetails = new ProblemDetails
                        {
                            Title = nameof(HttpStatusCode.NotFound),
                            Status = (int)HttpStatusCode.NotFound,
                            Detail = ExceptionConstants.ResourceNotFoundMessage
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        problemDetails = new ProblemDetails
                        {
                            Title = nameof(HttpStatusCode.InternalServerError),
                            Status = (int)HttpStatusCode.InternalServerError,
                            Detail = ExceptionConstants.UnexpectedErrorMessage,
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                context.Response.ContentType = problemJsonType;

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}