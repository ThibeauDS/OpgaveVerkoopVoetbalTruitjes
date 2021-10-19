﻿using System;
using VerkoopVoetbalTruitjes.Domain.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Beheerders
{
    public class KlantBeheerder
    {
        #region Properties
        private IKlantRepository _repo;
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
                if (_repo.BestaatKlant(klant))
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
                if (!_repo.BestaatKlant(klant))
                {
                    throw new KlantBeheerderException("Klant bestaat niet.");
                }
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
                if (!_repo.BestaatKlant(klant))
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

        public void KlantWeergeven(Klant klant)
        {
            try
            {
                if (!_repo.BestaatKlant(klant))
                {
                    throw new KlantBeheerderException("Klant bestaat niet.");
                }
                _repo.KlantWeergeven(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}