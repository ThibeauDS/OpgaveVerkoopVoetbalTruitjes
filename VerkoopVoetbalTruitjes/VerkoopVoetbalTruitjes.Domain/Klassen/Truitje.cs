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
        private VoetbalTruiMaten _maat;
        private string _seizoen;
        private decimal _prijs;
        private int _id;
        private Club _club;
        private Clubset _clubset;
        #endregion
    }
}
