using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class BadRequestException : BaseScimException
    {
        public BadRequestException() : base()
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BadRequestException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public BadRequestException(ErrorResponse res)
            : base(res, "Request is unparsable, syntactically incorrect, or violates schema.") { }
    }
}
