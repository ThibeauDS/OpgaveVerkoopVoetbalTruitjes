using System;
using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Beheerders
{
    public class KlantBeheerder
    {
        #region Properties
        private readonly IKlantRepository _repo;
        #endregion

        #region Constructors
        public KlantBeheerder(IKlantRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public void KlantToevoegen(Klant klant)
        {
            try
            {
                if (klant == null)
                {
                    throw new KlantBeheerderException("Klant is null.");
                }
                if (_repo.BestaatKlant(klant.KlantId))
                {
                    throw new KlantBeheerderException("Klant bestaat al.");
                }
                _repo.KlantToevoegen(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public void KlantVerwijderen(Klant klant)
        {
            try
            {
                //if (!_repo.BestaatKlant(klant.KlantId))
                //{
                //    throw new KlantBeheerderException("Klant bestaat niet.");
                //}
                _repo.KlantVerwijderen(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public void KlantUpdaten(Klant klant)
        {
            try
            {
                if (!_repo.BestaatKlant(klant.KlantId))
                {
                    throw new KlantBeheerderException("Klant bestaat niet.");
                }
                _repo.KlantUpdaten(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public List<Klant> KlantWeergeven(int id, string naam, string adres)
        {
            try
            {
                //if (!_repo.BestaatKlant(klant.KlantId))
                //{
                //    throw new KlantBeheerderException("Klant bestaat niet.");
                //}
                return _repo.KlantWeergeven(id, naam, adres);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
