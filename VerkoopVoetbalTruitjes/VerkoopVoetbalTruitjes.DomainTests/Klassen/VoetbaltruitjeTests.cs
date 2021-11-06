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
    public class VoetbaltruitjeTests
    {
        #region Properties
        private readonly Voetbaltruitje _voetbaltruitje = new(1, new("Competitie", "Ploeg"), "Zomer", 60, Enums.Kledingmaat.L, new(true, 1));
        #endregion

        [Theory()]
        [InlineData(0)]
        public void ZetIdTest(int id)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetId(id));
        }

        [Theory()]
        [InlineData(0)]
        public void ZetPrijsTest(double prijs)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetPrijs(prijs));
        }

        [Theory()]
        [InlineData("")]
        public void ZetSeizoenTest(string seizoen)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetSeizoen(seizoen));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetSeizoenTest2(string seizoen)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetSeizoen(seizoen));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetClubTest(Club club)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetClub(club));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetClubSetTest(ClubSet clubSet)
        {
            Assert.Throws<VoetbaltruitjeException>(() => _voetbaltruitje.ZetClubSet(clubSet));
        }

        //[Fact()]
        //public void ToStringTest()
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