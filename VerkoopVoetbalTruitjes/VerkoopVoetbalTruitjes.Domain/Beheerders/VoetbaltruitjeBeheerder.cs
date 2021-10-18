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
    public class VoetbaltruitjeBeheerder
    {
        #region Properties
        private IVoetbaltruitjeRepository _repo;
        #endregion

        #region Constructors
        public VoetbaltruitjeBeheerder(IVoetbaltruitjeRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje)
        {
            try
            {
                if (_repo.BestaatVoetbaltruitje(voetbaltruitje))
                {
                    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat al.");
                }
                _repo.VoetbaltruitjeToevoegen(voetbaltruitje);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }

        public void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje)
        {
            try
            {
                if (!_repo.BestaatVoetbaltruitje(voetbaltruitje))
                {
                    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat niet.");
                }
                _repo.VoetbaltruitjeVerwijderen(voetbaltruitje);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }

        public void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje)
        {
            try
            {
                if (!_repo.BestaatVoetbaltruitje(voetbaltruitje))
                {
                    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat niet.");
                }
                _repo.VoetbaltruitjeUpdaten(voetbaltruitje);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }

        public void VoetbaltruitjeWeergeven(Voetbaltruitje voetbaltruitje)
        {
            try
            {
                if (!_repo.BestaatVoetbaltruitje(voetbaltruitje))
                {
                    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat niet.");
                }
                _repo.VoetbaltruitjeWeergeven(voetbaltruitje);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
