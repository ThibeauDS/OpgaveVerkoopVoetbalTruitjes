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
        public VoetbalTruiMaten Maat { get; set; }
        public string Seizoen { get; set; }
        public decimal Prijs { get; set; }
        public int Id { get; set; }
        public Club Club { get; set; }
        public Clubset Clubset { get; set; }
        #endregion

        #region Constructors
        public Truitje()
        {

        }
        #endregion
    }
}
