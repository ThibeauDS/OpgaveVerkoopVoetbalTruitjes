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
    public class ClubTests
    {
        #region Properties
        //private readonly Club _club = new("Competitie", "Ploeg");
        private Club _club;
        #endregion

        [Theory()]
        [InlineData("", "")]
        public void ClubTest(string competitie, string ploeg)
        {
            Assert.Throws<ClubException>(() => _club = new(competitie, ploeg));
        }

        [Theory()]
        [InlineData(null, null)]
        public void ClubTest2(string competitie, string ploeg)
        {
            Assert.Throws<ClubException>(() => _club = new(competitie, ploeg));
        }

        [Theory()]
        [InlineData("Competitie", "")]
        public void ClubTest3(string competitie, string ploeg)
        {
            Assert.Throws<ClubException>(() => _club = new(competitie, ploeg));
        }

        [Theory()]
        [InlineData("", "Ploeg")]
        public void ClubTest4(string competitie, string ploeg)
        {
            Assert.Throws<ClubException>(() => _club = new(competitie, ploeg));
        }

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