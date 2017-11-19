using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class PreconditionException : BaseScimException
    {
        public PreconditionException() : base()
        {
        }

        protected PreconditionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PreconditionException(string message) : base(message)
        {
        }

        public PreconditionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PreconditionException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public PreconditionException(ErrorResponse res)
            : base(res, "Failed to update.  Resource has changed on the server.")
        {
        }
    }
}
