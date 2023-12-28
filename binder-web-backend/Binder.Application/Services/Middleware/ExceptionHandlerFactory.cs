using System.Net;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Application.Services.Middleware
{
    public class ExceptionHandlerFactory : IExceptionHandlerFactory
    {
        public void HandleException(Exception exception, out ProblemDetails? problemDetails, HttpContext context)
        {
            switch (exception)
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
            };
        }
    }
}