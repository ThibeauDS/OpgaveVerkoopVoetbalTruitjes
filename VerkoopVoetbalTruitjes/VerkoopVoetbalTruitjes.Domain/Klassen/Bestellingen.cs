using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void VoegTruitjeToe() { }
        public void VerwijderTruitje() { }
        public void ZetBetaald() { }
        #endregion
    }
}
