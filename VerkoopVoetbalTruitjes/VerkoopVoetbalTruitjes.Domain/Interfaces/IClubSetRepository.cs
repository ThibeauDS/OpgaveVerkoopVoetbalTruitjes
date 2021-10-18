using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IClubSetRepository
    {
        bool BestaatClubSet(ClubSet club);
        void ClubSetToevoegen(ClubSet club);
        void ClubSetVerwijderen(ClubSet club);
        void ClubSetUpdaten(ClubSet club);
        void ClubSetWeergeven(ClubSet club);
    }
}
