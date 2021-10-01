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
        private Dictionary<Truitje, int> _aantalTruitjes;
        #endregion

        #region Constructors
        public Bestellingen(bool isBetaald, decimal verkoopprijs, Truitje truitje)
        {
            ZetBetaald(isBetaald);
            ZetDatum();
            ZetVerkoopprijs(verkoopprijs);
            VoegTruitjeToe(truitje.Maat, truitje.Club.Competitie, truitje.Club.PloegNaam, truitje.Clubset.UitThuis, truitje.Seizoen, truitje.Prijs, truitje.Id);
        }
        #endregion

        #region Methods
        public void VoegTruitjeToe(VoetbalTruiMaten maat, string competitie, string ploegnaam, string uitThuis, string seizoen, decimal prijs, int id)
        {
            if (!_aantalTruitjes.ContainsKey(new Truitje(maat, seizoen, prijs, id)))
            {
                _aantalTruitjes.Add(new Truitje(maat, seizoen, prijs, id), 1);
            }
            else
            {
                _aantalTruitjes.Where(c => c.Key == new Truitje(maat, seizoen, prijs, id));
                // TODO: Value van key +1
            }
        }
        public void VerwijderTruitje(VoetbalTruiMaten maat, string competitie, string ploegnaam, string uitThuis, string seizoen, decimal prijs, int id)
        {
            _aantalTruitjes.Remove(new Truitje(maat, seizoen, prijs, id));
        }
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
        //TODO: Equals en GetHashCode implementeren
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
