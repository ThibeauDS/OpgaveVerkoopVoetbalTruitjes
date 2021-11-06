using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Data.Exceptions
{
    [Serializable]
    public class BestellingRepositoryADOException : Exception
    {
        public BestellingRepositoryADOException()
        {
        }

        public BestellingRepositoryADOException(string message) : base(message)
        {
        }

        public BestellingRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BestellingRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
