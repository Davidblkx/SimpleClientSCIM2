using System;
using System.Runtime.Serialization;

namespace SimpleClientSCIM2.Exceptions
{
    public class NotFoundException : BaseScimException
    {
        public NotFoundException() : base()
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(ErrorResponse res, string message) : base(res, message)
        {
        }

        public NotFoundException(ErrorResponse res) 
            : base(res, "Specified resource (e.g., User) or endpoint does not exist.")
        {
        }
    }
}
