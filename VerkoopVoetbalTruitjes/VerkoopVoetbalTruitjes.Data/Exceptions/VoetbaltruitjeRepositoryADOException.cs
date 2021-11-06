using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Data.Exceptions
{
    [Serializable]
    public class VoetbaltruitjeRepositoryADOException : Exception
    {
        public VoetbaltruitjeRepositoryADOException()
        {
        }

        public VoetbaltruitjeRepositoryADOException(string message) : base(message)
        {
        }

        public VoetbaltruitjeRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VoetbaltruitjeRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
