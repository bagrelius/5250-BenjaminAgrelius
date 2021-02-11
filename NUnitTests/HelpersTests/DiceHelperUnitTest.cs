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

        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between1and6()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(1, 6);
            //Reset
            //Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }

        [Test]
        public void RollDice_Invalid_Roll_Forced_Should_Return_1()
        {
            //Arrange
            DiceHelper.ForcedRandomValue = 1;
            DiceHelper.ForceRollsToNotRandom = true;

            //Act
            var result = DiceHelper.RollDice(1, 1);
            //Reset
            DiceHelper.ForceRollsToNotRandom = false;
            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RollDice_Valid_Roll_2_Dice_6_Should_Return_Between2and12()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(2, 6);
            //Reset
            //Assert
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
        }

        [Test]
        public void RollDice_Invalid_Roll_0_Dice_10_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(0, 10);
            //Reset
            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Invalid_Roll_1_Dice_0_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(0, 10);
            //Reset
            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        {
            //Arrange
            DiceHelper.ForcedRandomValue = 5;
            DiceHelper.ForceRollsToNotRandom = true;

            //Act
            var result = DiceHelper.RollDice(1, 10);
            //Reset
            DiceHelper.ForceRollsToNotRandom = false;
            //Assert
            Assert.AreEqual(5, result);

        }

        [Test]
        public void RollDice_Valid_Roll_3_Dice_10_Fixed_5_Should_Return_5()
        {
            //Arrange
            DiceHelper.ForcedRandomValue = 5;
            DiceHelper.ForceRollsToNotRandom = true;

            //Act
            var result = DiceHelper.RollDice(1, 10);
            //Reset
            DiceHelper.ForceRollsToNotRandom = false;
            //Assert
            Assert.AreEqual(15, result);

        }

    }
}
