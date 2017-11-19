using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class ServerException : BaseScimException
    {
        public ServerException() : base()
        {
        }

        protected ServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ServerException(string message) : base(message)
        {
        }

        public ServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ServerException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public ServerException(ErrorResponse res)
            : base(res, "Server internal error")
        {
        }
    }
}
