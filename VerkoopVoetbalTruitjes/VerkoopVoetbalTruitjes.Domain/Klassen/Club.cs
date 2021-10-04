using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Club
    {
        #region Properties
        public string Competitie { get; private set; }
        public string PloegNaam { get; private set; }
        #endregion

        #region Constructors
        public Club(string competitie, string ploegNaam)
        {
            ZetCompetitie(competitie);
            ZetPloegNaam(ploegNaam);
        }
        #endregion

        #region Methods
        public void ZetCompetitie(string competitie)
        {
            Competitie = competitie;
        }
        public void ZetPloegNaam(string ploegNaam)
        {
            PloegNaam = ploegNaam;
        }
        #endregion
    }
}
