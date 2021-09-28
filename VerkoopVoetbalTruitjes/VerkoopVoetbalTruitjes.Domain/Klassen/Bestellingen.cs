using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Enums;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Bestellingen
    {
        #region Properties
        private DateTime _dateTime;
        private int _bestellingsNummer;
        private decimal _verkoopprijs;
        private bool _betaald;
        #endregion

        #region Constructors
        public Bestellingen() { }
        #endregion

        #region Methods
        public void VoegTruitjeToe(VoetbalTruiMaten maat, string competitie, string ploegnaam, string uitThuis, string seizoen)
        {
            
        }
        public void VerwijderTruitje() { }
        public void ZetBetaald(bool isBetaald)
        {
            _betaald = isBetaald;
        }
        #endregion
    }
}
