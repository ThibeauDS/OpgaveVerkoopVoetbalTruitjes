using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    [Serializable]
    public class ClubException : Exception
    {
        public ClubException()
        {
        }

        public ClubException(string? message) : base(message)
        {
        }

        public ClubException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClubException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}