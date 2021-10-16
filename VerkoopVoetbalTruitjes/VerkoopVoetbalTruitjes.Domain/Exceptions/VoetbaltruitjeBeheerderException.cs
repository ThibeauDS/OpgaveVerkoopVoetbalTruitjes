using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    [Serializable]
    public class VoetbaltruitjeBeheerderException : Exception
    {
        public VoetbaltruitjeBeheerderException()
        {
        }

        public VoetbaltruitjeBeheerderException(string message) : base(message)
        {
        }

        public VoetbaltruitjeBeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VoetbaltruitjeBeheerderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
