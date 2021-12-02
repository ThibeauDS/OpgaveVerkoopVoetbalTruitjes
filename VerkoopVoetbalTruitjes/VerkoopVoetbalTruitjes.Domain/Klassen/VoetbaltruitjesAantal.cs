using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class VoetbaltruitjesAantal
    {
        #region Properties
        public Voetbaltruitje Voetbaltruitje { get; set; }
        public int Aantal { get; set; }
        #endregion

        #region Constructors
        public VoetbaltruitjesAantal(Voetbaltruitje voetbaltruitje, int aantal) : this(voetbaltruitje)
        {
            Aantal = aantal;
        }

        public VoetbaltruitjesAantal(Voetbaltruitje voetbaltruitje)
        {
            Voetbaltruitje = voetbaltruitje;
        }
        #endregion

        #region Methods
        public void ZetVoetbaltruitje(Voetbaltruitje voetbaltruitje)
        {
            if (Voetbaltruitje == null)
            {
                throw new VoetbaltruitjesAantalException("Het kan niet leeg zijn.");
            }
            Voetbaltruitje = voetbaltruitje;
        }

        public void ZetAantal(int aantal)
        {
            if (aantal >= 0)
            {
                throw new VoetbaltruitjesAantalException("Het kan niet 0 of kleiner zijn.");
            }
            Aantal = aantal;
        }
        #endregion
    }
}
