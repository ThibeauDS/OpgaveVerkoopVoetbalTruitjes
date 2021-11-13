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
                if (_repo.BestaatVoetbaltruitje(voetbaltruitje.Id))
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
                if (!_repo.BestaatVoetbaltruitje(voetbaltruitje.Id))
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
                if (!_repo.BestaatVoetbaltruitje(voetbaltruitje.Id))
                {
                    //voetbaltruitje dbVoetbaltruitje = 
                    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat niet.");
                }
                _repo.VoetbaltruitjeUpdaten(voetbaltruitje);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }

        public IReadOnlyList<Voetbaltruitje> VoetbaltruitjeWeergeven(int id, string competitie, string ploeg, string seizoen, double? prijs, bool? thuis, int versie, string maat)
        {
            try
            {
                //if (!_repo.BestaatVoetbaltruitje(id))
                //{
                //    throw new VoetbaltruitjeBeheerderException("Voetbaltruitje bestaat niet.");
                //}
                return _repo.VoetbaltruitjeWeergeven(id, competitie, ploeg, seizoen, prijs, thuis, versie, maat);
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeBeheerderException(ex.Message);
            }
        }
        //public IReadOnlyList<Voetbaltruitje> ZoekTruitje(int? voetbaltruitjeId, string competitie, string club, string seizoen, string kledingmaat, int? versie, bool? thuis, double? prijs)
        //{
        //    List<Voetbaltruitje> truitjes = new();
        //    try
        //    {
        //        if (false)
        //        {
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrWhiteSpace(competitie) || !string.IsNullOrWhiteSpace(club) || !string.IsNullOrWhiteSpace(seizoen) || !string.IsNullOrWhiteSpace(kledingmaat) || versie.HasValue || thuis.HasValue || prijs.HasValue)
        //            {
        //                truitjes.AddRange(_repo.GeefTruitjes(competitie, club, seizoen, kledingmaat, versie, thuis, prijs));
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
    }
}
