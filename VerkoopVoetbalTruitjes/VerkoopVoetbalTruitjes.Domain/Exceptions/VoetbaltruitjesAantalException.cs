using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    [Serializable]
    public class VoetbaltruitjesAantalException : Exception
    {
        public VoetbaltruitjesAantalException()
        {
        }

        public VoetbaltruitjesAantalException(string message) : base(message)
        {
        }

        public VoetbaltruitjesAantalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VoetbaltruitjesAantalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
