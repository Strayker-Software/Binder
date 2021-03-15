using System;

namespace Binder.Exceptions
{
    /// <summary>
    /// Exception class for database paths errors.
    /// </summary>
    [Serializable]
    public class DatabasePathException : Exception
    {
        /// <summary>
        /// Constructor for DatabasePathException.
        /// </summary>
        public DatabasePathException() { throw new NotImplementedException("This class has 'work in progress' status."); }
        /// <summary>
        /// Constructor overload for message support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        public DatabasePathException(string message) : base(message) { throw new NotImplementedException("This class has 'work in progress' status."); }
        /// <summary>
        /// Constructor overload for message and inner exception support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        /// <param name="inner">Inner exception.</param>
        public DatabasePathException(string message, Exception inner) : base(message, inner) { throw new NotImplementedException("This class has 'work in progress' status."); }
        /// <summary>
        /// Constructor overload for serialization info and streaming context.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected DatabasePathException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { throw new NotImplementedException("This class has 'work in progress' status."); }
    }
}
