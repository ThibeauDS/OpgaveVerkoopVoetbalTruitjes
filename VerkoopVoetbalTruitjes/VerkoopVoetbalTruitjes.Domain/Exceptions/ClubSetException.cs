using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    [Serializable]
    internal class ClubSetException : Exception
    {
        public ClubSetException()
        {
        }

        public ClubSetException(string? message) : base(message)
        {
        }

        public ClubSetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClubSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}