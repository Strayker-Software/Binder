using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Binder.Exceptions
{
    /// <summary>
    /// Exception handling class for error data management.
    /// </summary>
    public class StandardExceptionHandler : IExceptionHandler
    {
        private readonly Exception ExceptionToRecognise;

        /// <summary>
        /// Code for given error, points to error's description in Binder's errors' list.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Message for user to understand given error.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Constructor for StandardExceptionHandler.
        /// </summary>
        /// <param name="x">Exception to handle and redirect.</param>
        public StandardExceptionHandler(Exception x)
        {
            ExceptionToRecognise = x;
        }

        /// <summary>
        /// Redirects loaded exception to show user importand data to get help quicker.
        /// </summary>
        public void RedirectException()
        {
            if(ExceptionToRecognise.GetType() == typeof(FileNotFoundException))
            {
                ErrorCode = 2;
                Message = "Database not found.";
            }
            else if (ExceptionToRecognise.GetType() == typeof(ArgumentException))
            {
                ErrorCode = 1;
                Message = "Database path is wrong.";
            }
            else
            {
                ErrorCode = -1;
                Message = "Unrecognised error.";
            }

            ShowMessageBox();
        }

        private void ShowMessageBox()
        {
            var msg = new StringBuilder();
            msg.AppendFormat("Error in Binder!\nError Code: {0}\nException Name: {1}\nMessage: {2}\nIf you need help, contact Strayker Software at https://straykersoftware.pl", ErrorCode, ExceptionToRecognise.GetType().Name, Message);
            MessageBox.Show(msg.ToString(), "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
