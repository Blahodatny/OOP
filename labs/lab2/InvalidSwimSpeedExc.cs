using System;
using System.Runtime.Serialization;

namespace lab2
{
    public class InvalidSwimSpeedExc : SystemException
    {
        protected InvalidSwimSpeedExc(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidSwimSpeedExc(string message) : base(message)
        {
            Console.Error.WriteLine(message);
        }

        public InvalidSwimSpeedExc(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}