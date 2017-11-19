using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class ConflitException : BaseScimException
    {
        public ConflitException() : base()
        {
        }

        protected ConflitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConflitException(string message) : base(message)
        {
        }

        public ConflitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConflitException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public ConflitException(ErrorResponse res)
            : base(res, "The specified version number does not match " +
                  "the resource's latest version number, or a service " +
                  "provider refused to create a new, duplicate resource.")
        {
        }
    }
}
