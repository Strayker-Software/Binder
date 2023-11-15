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
                ProblemDetails problemDetails;
                switch (e)
                {
                    case InvalidOperationException invalidOperationException:
                        problemDetails = new ProblemDetails
                        {
                            Title = ExceptionConstants.InvalidOperationMessage,
                            Status = (int)HttpStatusCode.BadRequest,
                            Detail = invalidOperationException.Message
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundException notFoundException:
                        problemDetails = new ProblemDetails
                        {
                            Title = ExceptionConstants.ResourceNotFoundMessage,
                            Status = (int)HttpStatusCode.NotFound,
                            Detail = notFoundException.Message
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        problemDetails = new ProblemDetails
                        {
                            Title = ExceptionConstants.UnexpectedErrorMessage,
                            Status = (int)HttpStatusCode.InternalServerError,
                            Detail = e.Message
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