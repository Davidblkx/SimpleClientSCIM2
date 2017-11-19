using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class UnxpectedResponseException : BaseScimException
    {
        public UnxpectedResponseException(int status)
            : base("Unxpected server response, status do not match documentation")
        {
            ErrorDetails = new ErrorResponse
            {
                Status = status.ToString()
            };
        }

        public UnxpectedResponseException() : base()
        {
        }

        protected UnxpectedResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnxpectedResponseException(string message) : base(message)
        {
        }

        public UnxpectedResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnxpectedResponseException(ErrorResponse res, string message) : base(res, message)
        {
        }
    }
}
