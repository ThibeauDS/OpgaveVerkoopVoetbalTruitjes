using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    internal interface IVoetbaltruitjeRepository
    {
        public List<Voetbaltruitje> GeefTruitjes();
    }
}
