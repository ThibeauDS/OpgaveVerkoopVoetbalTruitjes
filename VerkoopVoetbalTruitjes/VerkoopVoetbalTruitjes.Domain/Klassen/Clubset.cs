using System;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class ClubSet
    {
        public ClubSet(bool thuis, int versie)
        {
            Thuis = thuis;
            if (versie < 0) throw new ClubSetException("Clubset - versie < 1");
            Versie = versie;
        }

        public bool Thuis { get; private set; }//vs uit
        public int Versie { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is ClubSet set &&
                   Thuis == set.Thuis &&
                   Versie == set.Versie;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Thuis, Versie);
        }
        public override string ToString()
        {
            if (Thuis)
                return $"Thuis - {Versie}";
            else
                return $"Uit - {Versie}";
        }
    }
}
