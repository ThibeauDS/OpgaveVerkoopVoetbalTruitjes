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
    public class ClubSetTests
    {
        #region Properties
        private ClubSet _clubSet;
        #endregion

        [Theory()]
        [InlineData(true, -1)]
        public void ClubSetTest(bool thuis, int versie)
        {
            Assert.Throws<ClubSetException>(() => _clubSet = new(thuis, versie));
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

        //[Fact()]
        //public void ToStringTest()
        //{
        //    Assert.True(false, "This test needs an implementation");
        //}
    }
}