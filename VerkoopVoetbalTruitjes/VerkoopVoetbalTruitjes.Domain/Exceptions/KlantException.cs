using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerkoopVoetbalTruitjes.Domain.Exceptions
{
    public class KlantException : Exception
    {
        public KlantException(string? message) : base(message)
        {
        }
    }
}
