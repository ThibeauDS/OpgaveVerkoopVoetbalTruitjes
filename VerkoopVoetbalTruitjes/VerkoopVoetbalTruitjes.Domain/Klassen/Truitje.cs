using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Enums;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Truitje
    {
        #region Properties
        public VoetbalTruiMaten Maat { get; private set; }
        public string Seizoen { get; private set; }
        public decimal Prijs { get; private set; }
        public int Id { get; private set; }
        public Club Club { get; set; }
        public Clubset Clubset { get; set; }
        #endregion

        #region Constructors
        public Truitje(VoetbalTruiMaten maat, string seizoen, decimal prijs, int id)
        {
            ZetMaat(maat);
            ZetSeizoen(seizoen);
            ZetPrijs(prijs);
            ZetId(id);
        }
        #endregion

        #region Methods
        public void ZetMaat(VoetbalTruiMaten maat)
        {
            Maat = maat;
        }
        public void ZetSeizoen(string seizoen)
        {
            Seizoen = seizoen;
        }
        public void ZetPrijs(decimal prijs)
        {
            Prijs = prijs;
        }
        public void ZetId(int id)
        {
            Id = id;
        }
        #endregion
        //TODO: Correcte implementatie van de klasse Truitje.cs
    }
}
