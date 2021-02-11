using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnitTests.Models
{
    [TestFixture]
    class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Valid_Default_Should_Pass()
        {
            //Arrange


            //Act
            var result = new ItemModelTests();

            //Reset


            //Assert
            Assert.IsNotNull(result);
        }
    }
}
