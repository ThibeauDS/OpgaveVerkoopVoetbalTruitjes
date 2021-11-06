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
    public class KlantTests
    {
        #region Properties
        private readonly List<Bestelling> _bestellings = new();
        private readonly Dictionary<Voetbaltruitje, int> _voetblatruitjeKeys = new();
        private readonly Voetbaltruitje _voetbaltruitje;
        private readonly Club _club;
        private readonly ClubSet _clubSet;
        private readonly Klant _klant;
        private readonly Bestelling _bestelling;
        #endregion

        #region Constructors
        public KlantTests()
        {
            _club = new("Competitie", "Ploeg");
            _clubSet = new(true, 1);
            _voetbaltruitje = new(1, _club, "Zomer", 30, Enums.Kledingmaat.M, _clubSet);
            _voetblatruitjeKeys.Add(_voetbaltruitje, 1);
            _klant = new(1, "Thibeau De Smet", "Sleistraat 26A 9550 Herzele", _bestellings);
            _bestelling = new(1, _klant, DateTime.Now, 50, false, _voetblatruitjeKeys);
            _bestellings.Add(_bestelling);
        }
        #endregion

        [Theory()]
        [InlineData(0)]
        public void ZetKlantIdTest(int id)
        {
            Assert.Throws<KlantException>(() => _klant.ZetKlantId(id));
        }

        [Theory()]
        [InlineData("")]
        public void ZetNaamTest(string naam)
        {
            Assert.Throws<KlantException>(() => _klant.ZetNaam(naam));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetNaamTest2(string naam)
        {
            Assert.Throws<KlantException>(() => _klant.ZetNaam(naam));
        }

        [Theory()]
        [InlineData("")]
        public void ZetAdresTest(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetAdresTest2(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        //[Fact()]
        //public void GetBestellingenTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        [Fact()]
        public void VerwijderBestellingTest()
        {
            Bestelling bestelling = null;
            Assert.Throws<KlantException>(() => _klant.VerwijderBestelling(bestelling));
        }

        [Fact()]
        public void VerwijderBestellingTest2()
        {
            Klant klant = new("Test", "TestAdres");
            Bestelling bestelling = new(10, klant, DateTime.Now.AddDays(-5), 99, true, _voetblatruitjeKeys);
            Assert.Throws<KlantException>(() => _klant.VerwijderBestelling(bestelling));
        }

        [Fact()]
        public void VoegToeBestellingTest()
        {
            Bestelling bestelling = null;
            Assert.Throws<KlantException>(() => _klant.VoegToeBestelling(bestelling));
        }

        [Fact()]
        public void VoegToeBestellingTest2()
        {
            Assert.Throws<KlantException>(() => _klant.VoegToeBestelling(_bestelling));
        }

        [Fact()]
        public void HeeftBestellingTest()
        {
            Assert.True(_klant.HeeftBestelling(_bestelling));
        }

        [Fact()]
        public void HeeftBestellingTest2()
        {
            Klant klant = new("Test", "TestAdres");
            Bestelling bestelling = new(10, klant, DateTime.Now.AddDays(-5), 99, true, _voetblatruitjeKeys);
            Assert.False(_klant.HeeftBestelling(bestelling));
        }

        //[Fact()]
        //public void KortingTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void ToStringTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void ToTextTest()
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