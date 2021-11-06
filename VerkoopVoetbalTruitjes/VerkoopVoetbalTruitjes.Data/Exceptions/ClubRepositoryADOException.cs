using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Data.Exceptions
{
    [Serializable]
    public class ClubRepositoryADOException : Exception
    {
        public ClubRepositoryADOException()
        {
        }

        public ClubRepositoryADOException(string message) : base(message)
        {
        }

        public ClubRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClubRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
