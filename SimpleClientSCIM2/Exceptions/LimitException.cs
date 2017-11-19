using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class LimitException : BaseScimException
    {
        public LimitException() : base()
        {
        }

        protected LimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LimitException(string message) : base(message)
        {
        }

        public LimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public LimitException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public LimitException(ErrorResponse res)
            : base(res, "Payload size exceed or max operation reached")
        {
        }
    }
}
