using System.Net;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Application.Services.Middleware
{
    public static class GetProblemDetailsByExceptionFactory
    {
        public static ProblemDetails GetProblemDetails(Exception exception)
        {
            return exception switch
            {
                InvalidOperationException => new ProblemDetails
                {
                    Title = nameof(HttpStatusCode.BadRequest),
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = ExceptionConstants.InvalidOperationMessage,
                },
                NotFoundException => new ProblemDetails
                {
                    Title = nameof(HttpStatusCode.NotFound),
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = ExceptionConstants.ResourceNotFoundMessage
                },
                _ => new ProblemDetails
                {
                    Title = nameof(HttpStatusCode.InternalServerError),
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = ExceptionConstants.UnexpectedErrorMessage,
                },
            };            
        }
    }
}