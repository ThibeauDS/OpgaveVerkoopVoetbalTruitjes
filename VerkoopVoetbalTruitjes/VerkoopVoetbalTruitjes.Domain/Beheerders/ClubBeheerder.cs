using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
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
                if (string.IsNullOrWhiteSpace(competitie))
                {
                    throw new ClubBeheerderException("Competitie mag niet leeg zijn.");
                }

                //if (!_repo.BestaatCompetitie(competitie))
                //{
                //    throw new ClubBeheerderException("Competitie bestaat niet.");
                //}
                return _repo.GeefPloegen(competitie);
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
