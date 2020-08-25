using System;

namespace Binder
{ // TODO: Make every exception in separate file!
    /// <summary>
    /// Exception class for database errors.
    /// </summary>
    [Serializable]
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Constructor for DatabaseException.
        /// </summary>
        public DatabaseException() { }
        /// <summary>
        /// Constructor overload for message support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        public DatabaseException(string message) : base(message) { }
        /// <summary>
        /// Constructor overload for message and inner exception support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        /// <param name="inner">Inner exception.</param>
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Constructor overload for serialization info and streaming context.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected DatabaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Exception class for database paths errors.
    /// </summary>
    [Serializable]
    public class DatabasePathException : Exception
    {
        /// <summary>
        /// Constructor for DatabasePathException.
        /// </summary>
        public DatabasePathException() { }
        /// <summary>
        /// Constructor overload for message support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        public DatabasePathException(string message) : base(message) { }
        /// <summary>
        /// Constructor overload for message and inner exception support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        /// <param name="inner">Inner exception.</param>
        public DatabasePathException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Constructor overload for serialization info and streaming context.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected DatabasePathException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Exception class for unrecognised errors.
    /// </summary>
    [Serializable]
    public class UnrecognisedErrorException : Exception
    {
        /// <summary>
        /// Constructor for UnrecognisedErrorException.
        /// </summary>
        public UnrecognisedErrorException() { }
        /// <summary>
        /// Constructor overload for message support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        public UnrecognisedErrorException(string message) : base(message) { }
        /// <summary>
        /// Constructor overload for message and inner exception support.
        /// </summary>
        /// <param name="message">Message to be send back to calling instruction.</param>
        /// <param name="inner">Inner exception.</param>
        public UnrecognisedErrorException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Constructor overload for serialization info and streaming context.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected UnrecognisedErrorException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
