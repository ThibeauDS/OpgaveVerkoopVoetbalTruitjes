using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IVoetbaltruitjeRepository
    {
        bool BestaatVoetbaltruitje(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeWeergeven(Voetbaltruitje voetbaltruitje);
    }
}
