using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IBestellingRepository
    {
        bool BestaatBestelling(Bestelling bestelling);
        void BestellingToevoegen(Bestelling bestelling);
        void BestellingVerwijderen(Bestelling bestelling);
        void BestellingUpdaten(Bestelling bestelling);
        void BestellingWeergeven(Bestelling bestelling);
    }
}
