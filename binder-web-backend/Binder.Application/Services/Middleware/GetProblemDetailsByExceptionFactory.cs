using System.Net;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Application.Services.Middleware
{
    public static class GetProblemDetailsByExceptionFactory
    {
        public static ProblemDetails HandleException(Exception exception)
        {
            ProblemDetails problemDetails;
            switch (exception)
            {
                case InvalidOperationException:
                    problemDetails = new ProblemDetails
                    {
                        Title = nameof(HttpStatusCode.BadRequest),
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = ExceptionConstants.InvalidOperationMessage,
                    };
                    break;
                case NotFoundException:
                    problemDetails = new ProblemDetails
                    {
                        Title = nameof(HttpStatusCode.NotFound),
                        Status = (int)HttpStatusCode.NotFound,
                        Detail = ExceptionConstants.ResourceNotFoundMessage
                    };
                    break;
                default:
                    problemDetails = new ProblemDetails
                    {
                        Title = nameof(HttpStatusCode.InternalServerError),
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = ExceptionConstants.UnexpectedErrorMessage,
                    };
                    break;
            };

            return problemDetails;
        }
    }
}