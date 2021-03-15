using System;
using System.Runtime.Serialization;

namespace Binder.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class UnrecognisedException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public UnrecognisedException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public UnrecognisedException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public UnrecognisedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected UnrecognisedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
