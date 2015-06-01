using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HarryPotterKata.Tests.Models
{
    [TestClass]
    public class BookTest : HarryPotterTests
    {
        // BookTest
        [Test]
        public void OneBookCosts8Euros()
        {
            // Act
            Expected = 8.00m;
            Actual = Book.GetPrice();

            // Assert
            Assert.AreEqual(Expected, Actual);
        }
    }
}