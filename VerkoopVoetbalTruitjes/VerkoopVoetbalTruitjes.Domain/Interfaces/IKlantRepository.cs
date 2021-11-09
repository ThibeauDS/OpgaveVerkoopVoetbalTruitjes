using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IKlantRepository
    {
        bool BestaatKlant(int id);
        void KlantToevoegen(Klant klant);
        void KlantVerwijderen(Klant klant);
        void KlantUpdaten(Klant klant);
        Klant KlantWeergeven(Klant klant);
    }
}
