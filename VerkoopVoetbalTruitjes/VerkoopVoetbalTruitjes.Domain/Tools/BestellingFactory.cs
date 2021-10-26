using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Tools
{
    public static class BestellingFactory
    {
        public static Bestelling MaakBestelling()
        {
            try
            {
                return new Bestelling(DateTime.Now);
            }
            catch (Exception ex)
            {
                throw new Exception("Maakbestelling: ", ex);
            }
        }
    }
}
