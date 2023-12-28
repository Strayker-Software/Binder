using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Application.Services.Middleware
{
    public interface IExceptionHandlerFactory
    {
        void HandleException(Exception exception, out ProblemDetails? problemDetails, HttpContext context);
    }
}