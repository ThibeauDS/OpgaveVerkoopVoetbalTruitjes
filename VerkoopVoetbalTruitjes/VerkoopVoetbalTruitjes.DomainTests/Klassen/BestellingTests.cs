using Xunit;
using VerkoopVoetbalTruitjes.Domain.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen.Tests
{
    public class BestellingTests
    {
        #region Properties
        private readonly Klant _klant;
        private readonly Voetbaltruitje _voetbaltruitje;
        private readonly Dictionary<Voetbaltruitje, int> _voetbaltruitjeKeys = new();
        private readonly Bestelling _bestelling;
        #endregion

        #region Constructors
        public BestellingTests()
        {
            _klant = new(1, "Thibeau", "MijnHuidigAdres");
            _voetbaltruitje = new(1, new("Competitie", "Ploeg"), "Zomer", 60, Enums.Kledingmaat.L, new(true, 1));
            _voetbaltruitjeKeys.Add(_voetbaltruitje, 1);
            _bestelling = new(1, _klant, DateTime.Now, 30, true, _voetbaltruitjeKeys);
        }
        #endregion

        [Theory()]
        [InlineData(null, 0)]
        public void VoegProductToeTest(Voetbaltruitje voetbaltruitje, int aantal)
        {
            Assert.Throws<BestellingException>(() => _bestelling.VoegProductToe(voetbaltruitje, aantal));
        }

        [Theory()]
        [InlineData(null, 1)]
        public void VoegProductToeTest2(Voetbaltruitje voetbaltruitje, int aantal)
        {
            Assert.Throws<BestellingException>(() => _bestelling.VoegProductToe(voetbaltruitje, aantal));
        }

        [Fact()]
        public void VoegProductToeTest3()
        {
            int aantal = 0;
            Voetbaltruitje voetbaltruitje = new(2, new("Competitie", "Ploeg"), "Winter", 20, Enums.Kledingmaat.M, new(true, 1));
            Assert.Throws<BestellingException>(() => _bestelling.VoegProductToe(voetbaltruitje, aantal));
        }

        [Fact()]
        public void VoegProductToeTest4()
        {
            int aantal = 0;
            Assert.Throws<BestellingException>(() => _bestelling.VoegProductToe(_voetbaltruitje, aantal));
        }

        [Theory()]
        [InlineData(null, 0)]
        public void VerwijderProductTest(Voetbaltruitje voetbaltruitje, int aantal)
        {
            Assert.Throws<BestellingException>(() => _bestelling.VerwijderProduct(voetbaltruitje, aantal));
        }

        [Theory()]
        [InlineData(null, 1)]
        public void VerwijderProductTest2(Voetbaltruitje voetbaltruitje, int aantal)
        {
            Assert.Throws<BestellingException>(() => _bestelling.VerwijderProduct(voetbaltruitje, aantal));
        }

        [Fact()]
        public void VerwijderProductTest3()
        {
            int aantal = 0;
            Voetbaltruitje voetbaltruitje = new(2, new("Competitie", "Ploeg"), "Winter", 20, Enums.Kledingmaat.M, new(true, 1));
            Assert.Throws<BestellingException>(() => _bestelling.VerwijderProduct(voetbaltruitje, aantal));
        }

        [Fact()]
        public void VerwijderProductTest4()
        {
            int aantal = 0;
            Assert.Throws<BestellingException>(() => _bestelling.VerwijderProduct(_voetbaltruitje, aantal));
        }

        //[Fact()]
        //public void GeefProductenTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void KostprijsTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Theory()]
        //[InlineData(null)]
        //public void VerwijderKlantTest(Klant klant)
        //{
        //    Assert.Throws<BestellingException>(() => _bestelling.VerwijderKlant(klant));
        //}

        [Theory()]
        [InlineData(null)]
        public void ZetKlantTest(Klant klant)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetKlant(klant));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetKlantTest2(Klant klant)
        {
            klant = _klant;
            Assert.Throws<BestellingException>(() => _bestelling.ZetKlant(klant));
        }

        [Theory()]
        [InlineData(0)]
        public void ZetBestellingIdTest(int id)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetBestellingId(id));
        }

        [Fact()]
        public void ZetTijdstipTest()
        {
            DateTime dt = DateTime.Now.AddDays(1);
            Assert.Throws<BestellingException>(() => _bestelling.ZetTijdstip(dt));
        }

        //[Fact()]
        //public void ZetBetaaldTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void ToStringTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void ShowTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void EqualsTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void GetHashCodeTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}
    }
}