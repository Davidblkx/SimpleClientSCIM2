using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class ForbiddenException : BaseScimException
    {
        public ForbiddenException() : base()
        {
        }

        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ForbiddenException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public ForbiddenException(ErrorResponse res) 
            : base(res, "Operation is not permitted based on the supplied authorization.") { }
    }
}
