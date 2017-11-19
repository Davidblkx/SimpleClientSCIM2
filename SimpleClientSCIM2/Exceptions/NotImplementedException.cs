using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class NotImplementedException : BaseScimException
    {
        public NotImplementedException() : base()
        {
        }

        protected NotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotImplementedException(string message) : base(message)
        {
        }

        public NotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotImplementedException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public NotImplementedException(ErrorResponse res)
            : base(res, "Operation not supported")
        {
        }
    }
}
