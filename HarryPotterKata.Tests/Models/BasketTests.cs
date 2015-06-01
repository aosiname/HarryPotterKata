using System.Collections.Generic;
using HarryPotterKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HarryPotterKata.Tests.Models
{
    [TestClass]
    public class BasketTests : HarryPotterTests
    {
        // BasketTests
        [Test]
        public void BasketCanHoldACollectionOfBooks()
        {
            // Act
            var bookCollection = Basket.GetAllBooks();

            // Assert
            Assert.IsInstanceOfType(bookCollection, typeof(List<Book>));
        }

        [Test]
        public void CanAddBooksToBasket()
        {
            // Act
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            // Assert
            Expected = 2;
            Actual = Basket.GetAllBooks().Count;
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void BooksInBasketHavePrices()
        {
            // Act
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);
            Actual = Book1.GetPrice() + Book2.GetPrice();
            Expected = 16.00m;

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CountBooksInBasket()
        {
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);

            Expected = 2;

            // exemplifying use of properties over traditional transformers and accessors
            Actual = Basket.NumberOfItems;

            Assert.AreEqual(Expected, Actual);
        }

        [Test]
        public void CountDistinctBooksInBasket()
        {
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book1);
            Basket.AddBook(Book2);

            Expected = 2;

            // exemplifying use of properties over traditional transformers and accessors
            Actual = Basket.NumberOfDistinctItems;

            Assert.AreEqual(Expected, Actual);
        }
    }
}
