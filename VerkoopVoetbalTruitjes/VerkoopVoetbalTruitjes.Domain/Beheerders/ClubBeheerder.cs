using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;
using System.Collections.Generic;

namespace VerkoopVoetbalTruitjes.Domain.Beheerders
{
    public class ClubBeheerder
    {
        #region Properties
        private IClubRepository _repo;
        #endregion

        #region Constructors
        public ClubBeheerder(IClubRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public IReadOnlyList<string> GeefCompetities()
        {
            try
            {
                return _repo.GeefCompetities();
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }

        public IReadOnlyList<string> GeefPloegen(string competitie)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }
        //TODO: GeefCompetities _repo.GeefCompetities
        //TODO: GeefPloeg ... check eerst of het bestaat en of het leeg is dan GeefPloeg(string competitie)
        //TODO: Maak gebruik van IReadOnlyList van strings
        #endregion
    }
}
