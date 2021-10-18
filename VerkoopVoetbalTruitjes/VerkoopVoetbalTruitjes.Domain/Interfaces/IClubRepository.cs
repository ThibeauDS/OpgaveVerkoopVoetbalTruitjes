using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IClubRepository
    {
        bool BestaatClub(Club club);
        void ClubToevoegen(Club club);
        void ClubVerwijderen(Club club);
        void ClubUpdaten(Club club);
        void ClubWeergeven(Club club);
    }
}
