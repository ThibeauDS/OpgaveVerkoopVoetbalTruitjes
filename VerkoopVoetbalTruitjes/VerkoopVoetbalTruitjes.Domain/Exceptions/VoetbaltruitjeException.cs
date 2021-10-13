﻿using System;
using System.Runtime.Serialization;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    [Serializable]
    internal class VoetbaltruitjeException : Exception
    {
        public VoetbaltruitjeException()
        {
        }

        public VoetbaltruitjeException(string? message) : base(message)
        {
        }

        public VoetbaltruitjeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected VoetbaltruitjeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}