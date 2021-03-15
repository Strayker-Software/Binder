namespace Binder.Exceptions
{
    /// <summary>
    /// Interface for Binder's custom exception system.
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Method that recognises provided exception and handles it for app.
        /// </summary>
        void RedirectException();

        /// <summary>
        /// Error code for exception. Usefull for user to search for help.
        /// </summary>
        int ErrorCode
        {
            get;
        }

        /// <summary>
        /// String passed back to user as return message from app.
        /// </summary>
        string Message
        {
            get;
        }
    }
}
