namespace Binder.Application.Services.Middleware.CustomExceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}