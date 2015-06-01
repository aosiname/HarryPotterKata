using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HarryPotterKata.Tests.Models
{
    [TestClass]
    public class BookDiscountCalculatorTests : HarryPotterTests
    {
        // Calculator Tests
        [Test]
        public void CalculatorCanTotalPriceOfMoreThanOneBook()
        {
            // Act
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            // dont really like depending on the basket existing at this point - should really Mock the basket
            decimal value = BookDiscountCalculator.CalculateTotalPrice(Basket);

            // Assert
            Assert.IsTrue(Basket.GetAllBooks().Count > 0);
            Assert.IsNotNull(value);
            Assert.IsTrue(value >= 0);
        }

        [Test]
        public void CalculatePriceOfTwoDifferentBooks()
        {
            // Act
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            decimal percentageDiscount = 5 / 100m;
            Expected = (1 - percentageDiscount) * 16.00m;

            SetActualTotalPrice();

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfThreeDifferentBooks()
        {
            decimal percentageDiscount = 10 / 100m;
            Expected = (1 - percentageDiscount) * 24.00m;

            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book3);

            Assert.AreEqual(3, Basket.GetAllBooks().Count);
            SetActualTotalPrice();
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfFourDifferentBooks()
        {
            decimal percentageDiscount = 20 / 100m;
            Expected = (1 - percentageDiscount) * 32.00m;

            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book3);
            Basket.AddBook(Book4);

            SetActualTotalPrice();

            Assert.AreEqual(4, Basket.GetAllBooks().Count);
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfFiveDifferentBooks()
        {
            decimal percentageDiscount = 25 / 100m;
            Expected = (1 - percentageDiscount) * 40.00m;

            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book3);
            Basket.AddBook(Book4);
            Basket.AddBook(Book5);

            SetActualTotalPrice();

            Assert.AreEqual(5, Basket.GetAllBooks().Count);
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfTwoIdenticalBooks()
        {
            Expected = 16.00m; // feel i dont need to prove i can calculate the discount manually!

            Basket.AddBook(Book1);
            Basket.AddBook(Book1);

            SetActualTotalPrice();

            Assert.AreEqual(2, Basket.GetAllBooks().Count);
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfThreeIdenticalBooks()
        {
            Expected = 24.00m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);

            SetActualTotalPrice();

            Assert.AreEqual(Expected, Actual);
        }
        // assume above will work up till 5 books due to time constraint..!

        [Test]
        public void CalculatePriceOfTwoIdenticalBooksAndOneOtherBook()
        {
            Expected = 23.2m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            SetActualTotalPrice();

            Actual = RoundDecimalToXdp((decimal)Actual, 1);
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfThreeIdenticalBooksAndOneOtherBook()
        {
            Expected = 31.2m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            SetActualTotalPrice();

            Actual = RoundDecimalToXdp((decimal)Actual, 1);
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfFourIdenticalBooksAndOneOtherBook()
        {
            Expected = 39.2m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            SetActualTotalPrice();

            Actual = RoundDecimalToXdp((decimal)Actual, 1);
            Assert.AreEqual(Expected, Actual);
        }

        /*
         * 2 copies of the first book
         * 2 copies of the second book
         * 2 copies of the third book
         * 1 copy of the fourth book
         * 1 copy of the fifth book
         */
        [Test]
        public void CalculatePriceOfAboveConditionsToCompleteTheExercise()
        {
            Expected = 51.6m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book2);
            Basket.AddBook(Book3);
            Basket.AddBook(Book3);
            Basket.AddBook(Book4);
            Basket.AddBook(Book5);

            SetActualTotalPrice();

            Actual = RoundDecimalToXdp((decimal)Actual, 1);
            Assert.AreEqual(Expected, Actual);
        }

        // Calculator: Complex Basket Tests
        [Test]
        public void TestTwoIdenticalBooksAndOneOtherReturnsTwoBasketsWithUniqueBooksInside()
        {
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            var compicatedBasket = BookDiscountCalculator.CalculateComplicatedBasketCaseDiscount(Basket);

            Expected = 2; // two lists of baskets - one containing books 1,2 and the other containing book1
            Actual = compicatedBasket.Count;

            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void TestThreeIdenticalBooksAndOneOtherReturnsTwoBasketsWithUniqueBooksInside()
        {
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            var compicatedBasket = BookDiscountCalculator.CalculateComplicatedBasketCaseDiscount(Basket);

            Expected = 3; // two lists of baskets - one containing books 1,2 and the other containing book1
            Actual = compicatedBasket.Count;

            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void TestThreeBook1STwoBook2SThreeBook3SFourBook4SOneBook5Returns4Baskets()
        {
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book2);
            Basket.AddBook(Book3);
            Basket.AddBook(Book3);
            Basket.AddBook(Book3);
            Basket.AddBook(Book4);
            Basket.AddBook(Book4);
            Basket.AddBook(Book4);
            Basket.AddBook(Book4);
            Basket.AddBook(Book5);
            var compicatedBasket = BookDiscountCalculator.CalculateComplicatedBasketCaseDiscount(Basket);

            Expected = 4; // two lists of baskets - one containing books 1,2 and the other containing book1
            Actual = compicatedBasket.Count;

            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CalculatePriceOfTwoIdenticalBooksAndOTwoOtherIdentiacalBooks()
        {
            Expected = 30.40m;
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Basket.AddBook(Book2);

            SetActualTotalPrice();
            Assert.AreEqual(Expected, Actual);
        }
    }
}
