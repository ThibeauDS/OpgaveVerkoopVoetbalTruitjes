using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IKlantRepository
    {
        bool BestaatKlant(Klant klant);
        void KlantToevoegen(Klant klant);
        void KlantVerwijderen(Klant klant);
        void KlantUpdaten(Klant klant);
        void KlantWeergeven(Klant klant);
    }
}
