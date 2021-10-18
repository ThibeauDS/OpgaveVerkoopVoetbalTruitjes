using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Beheerders
{
    public class BestellingBeheerder
    {
        #region Properties
        private IBestellingRepository _repo;
        #endregion

        #region Constructors
        public BestellingBeheerder(IBestellingRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public void BestellingToevoegen(Bestelling bestelling)
        {
            try
            {
                if (_repo.BestaatBestelling(bestelling))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat al.");
                }
                _repo.BestellingToevoegen(bestelling);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException(ex.Message);
            }
        }

        public void BestellingVerwijderen(Bestelling bestelling)
        {
            try
            {
                if (!_repo.BestaatBestelling(bestelling))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat niet.");
                }
                _repo.BestellingVerwijderen(bestelling);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException(ex.Message);
            }
        }

        public void BestellingUpdaten(Bestelling bestelling)
        {
            try
            {
                if (!_repo.BestaatBestelling(bestelling))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat niet.");
                }
                _repo.BestellingUpdaten(bestelling);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException(ex.Message);
            }
        }

        public void BestellingWeergeven(Bestelling bestelling)
        {
            try
            {
                if (!_repo.BestaatBestelling(bestelling))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat niet.");
                }
                _repo.BestellingWeergeven(bestelling);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
