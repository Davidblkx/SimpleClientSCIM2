using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class UnauthorizedException : BaseScimException
    {
        public UnauthorizedException() : base()
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnauthorizedException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public UnauthorizedException(ErrorResponse res) 
            : base(res, "Authorization failure. The authorization header is invalid or missing") { }
    }
}
