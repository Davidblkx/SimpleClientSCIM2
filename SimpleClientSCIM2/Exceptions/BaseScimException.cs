using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class BaseScimException : Exception
    {
        public ErrorResponse ErrorDetails { get; protected set; }

        public BaseScimException() : base()
        {
        }

        protected BaseScimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BaseScimException(string message) : base(message)
        {
        }

        public BaseScimException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BaseScimException(ErrorResponse res, string message) : base(message)
        {
            ErrorDetails = res;
        }
    }
}
