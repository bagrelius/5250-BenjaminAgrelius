using Mine.Models;
using NUnit.Framework;
using Mine.Helpers;

namespace NUnitTests.HelpersTests
{
    [TestFixture]
    public class DiceHelperUnitTest
    {
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(0,1);
            //Reset
            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
