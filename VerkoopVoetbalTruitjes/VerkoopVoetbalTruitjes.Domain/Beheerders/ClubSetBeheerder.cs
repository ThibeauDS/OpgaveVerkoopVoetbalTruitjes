using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Beheerders
{
    public class ClubSetBeheerder
    {
        #region Properties
        private IClubSetRepository _repo;
        #endregion

        #region Constructors
        public ClubSetBeheerder(IClubSetRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public void ClubSetToevoegen(ClubSet clubSet)
        {
            try
            {
                if (_repo.BestaatClubSet(clubSet))
                {
                    throw new ClubSetBeheerderException("ClubSet bestaat al.");
                }
                _repo.ClubSetToevoegen(clubSet);
            }
            catch (Exception ex)
            {
                throw new ClubSetBeheerderException(ex.Message);
            }
        }

        public void ClubSetVerwijderen(ClubSet clubSet)
        {
            try
            {
                if (!_repo.BestaatClubSet(clubSet))
                {
                    throw new ClubSetBeheerderException("ClubSet bestaat niet.");
                }
                _repo.ClubSetVerwijderen(clubSet);
            }
            catch (Exception ex)
            {
                throw new ClubSetBeheerderException(ex.Message);
            }
        }

        public void ClubSetUpdaten(ClubSet clubSet)
        {
            try
            {
                if (!_repo.BestaatClubSet(clubSet))
                {
                    throw new ClubSetBeheerderException("Club bestaat niet.");
                }
                _repo.ClubSetUpdaten(clubSet);
            }
            catch (Exception ex)
            {
                throw new ClubSetBeheerderException(ex.Message);
            }
        }

        public void ClubSetWeergeven(ClubSet clubSet)
        {
            try
            {
                if (!_repo.BestaatClubSet(clubSet))
                {
                    throw new ClubSetBeheerderException("Club bestaat niet.");
                }
                _repo.ClubSetWeergeven(clubSet);
            }
            catch (Exception ex)
            {
                throw new ClubSetBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
