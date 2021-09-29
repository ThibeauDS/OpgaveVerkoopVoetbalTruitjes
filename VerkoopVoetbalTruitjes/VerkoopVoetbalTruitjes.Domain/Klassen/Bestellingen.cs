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
        public DateTime DateTime { get; private set; }
        public int BestellingsNummer { get; private set; }
        public decimal Verkoopprijs { get; private set; }
        public bool Betaald { get; private set; }
        #endregion

        #region Constructors
        public Bestellingen(bool isBetaald, decimal verkoopprijs)
        {
            ZetBetaald(isBetaald);
            ZetDatum();
            ZetVerkoopprijs(verkoopprijs);
        }
        #endregion

        #region Methods
        public void VoegTruitjeToe(VoetbalTruiMaten maat, string competitie, string ploegnaam, string uitThuis, string seizoen)
        {

        }
        public void VerwijderTruitje() { }
        public void ZetBetaald(bool isBetaald)
        {
            Betaald = isBetaald;
        }
        public void ZetDatum()
        {
            DateTime = DateTime.Now;
        }
        public void ZetVerkoopprijs(decimal verkoopprijs)
        {
            Verkoopprijs = verkoopprijs;
        }

        public override bool Equals(object? obj)
        {
            return obj is Bestellingen bestellingen &&
                   BestellingsNummer == bestellingen.BestellingsNummer;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BestellingsNummer);
        }
        #endregion
    }
}
