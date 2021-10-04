using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Clubset
    {
        #region Properties
        public string UitThuis { get; private set; }
        public int Versie { get; private set; }
        #endregion

        #region Constructors
        public Clubset(string uitThuis, int versie)
        {
            ZetUitThuis(uitThuis);
            ZetVersie(versie);
        }
        #endregion

        #region Methods
        public void ZetUitThuis(string uitThuis)
        {
            UitThuis = uitThuis;
        }
        public void ZetVersie(int versie)
        {
            Versie = versie;
        }
        #endregion
    }
}
