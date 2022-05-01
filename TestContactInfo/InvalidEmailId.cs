using System;
using System.Runtime.Serialization;

namespace TestContactInfo
{
    [Serializable]
    internal class InvalidEmailId : Exception
    {
        public InvalidEmailId()
        {
        }

        public InvalidEmailId(string message) : base(message)
        {
        }

        public InvalidEmailId(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEmailId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}