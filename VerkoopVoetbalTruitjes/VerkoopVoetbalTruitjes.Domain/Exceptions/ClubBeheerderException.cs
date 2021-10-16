using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    [Serializable]
    public class ClubBeheerderException : Exception
    {
        public ClubBeheerderException()
        {
        }

        public ClubBeheerderException(string message) : base(message)
        {
        }

        public ClubBeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClubBeheerderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
