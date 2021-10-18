using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

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
        public void ClubToevoegen(Club club)
        {
            try
            {
                if (_repo.BestaatClub(club))
                {
                    throw new ClubBeheerderException("Club bestaat al.");
                }
                _repo.ClubToevoegen(club);
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }

        public void ClubVerwijderen(Club club)
        {
            try
            {
                if (!_repo.BestaatClub(club))
                {
                    throw new ClubBeheerderException("Club bestaat niet.");
                }
                _repo.ClubVerwijderen(club);
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }

        public void ClubUpdaten(Club club)
        {
            try
            {
                if (!_repo.BestaatClub(club))
                {
                    throw new ClubBeheerderException("Club bestaat niet.");
                }
                _repo.ClubUpdaten(club);
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }

        public void ClubWeergeven(Club club)
        {
            try
            {
                if (!_repo.BestaatClub(club))
                {
                    throw new ClubBeheerderException("Club bestaat niet.");
                }
                _repo.ClubWeergeven(club);
            }
            catch (Exception ex)
            {
                throw new ClubBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
