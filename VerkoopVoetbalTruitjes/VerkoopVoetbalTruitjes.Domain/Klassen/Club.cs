using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Club
    {
        #region Properties
        public string Competitie { get; private set; }
        public string Ploeg { get; private set; }
        #endregion

        #region Constructors
        public Club(string competitie, string ploeg)
        {
            if (string.IsNullOrWhiteSpace(competitie) || string.IsNullOrWhiteSpace(ploeg))
                throw new ClubException("Club - null or empty");
            Competitie = competitie;
            Ploeg = ploeg;
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return obj is Club club &&
                   Competitie == club.Competitie &&
                   Ploeg == club.Ploeg;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Competitie, Ploeg);
        }
        #endregion
    }
}
