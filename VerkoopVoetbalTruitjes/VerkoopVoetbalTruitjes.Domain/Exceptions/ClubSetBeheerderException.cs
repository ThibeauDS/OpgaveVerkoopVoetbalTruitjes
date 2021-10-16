using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    [Serializable]
    public class ClubSetBeheerderException : Exception
    {
        public ClubSetBeheerderException()
        {
        }

        public ClubSetBeheerderException(string message) : base(message)
        {
        }

        public ClubSetBeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClubSetBeheerderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
