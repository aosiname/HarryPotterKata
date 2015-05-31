using System;
using System.Collections.Generic;
using System.Security.Policy;
using HarryPotterKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HarryPotterKata.Tests.Models
{
    [TestClass]
    public class BookTest
    {
        private Book book, book1, book2, book3, book4, book5;
        private object expected, actual;
        private Basket basket;
        private BookDiscountCalculator bookDiscountCalculator;

        // Setup
        public BookTest()
        {
            /***
                1. Harry Potter and the Philosopher's Stone
                2. Harry Potter and the Chamber of Secrets
                3. Harry Potter and the Prisoner of Azkaban
                4. Harry Potter and the Goblet of Fire
                5. Harry Potter and the Order of the Phoenix
                6. Harry Potter and the Half-Blood Prince
                7. Harry Potter and the Deathly Hallows
             */
            book = new Book(8.00m);

            book1 = new Book(8.00m);
            book1.setID(1);
            book1.setTitle("Harry Potter and the Philosopher's Stone");

            book2 = new Book(8.00m);
            book2.setID(2);
            book2.setTitle("Harry Potter and the Chamber of Secrets");

            book3 = new Book(8.00m);
            book3.setID(3);
            book3.setTitle("Harry Potter and the Prisoner of Azkaban");

            book4 = new Book(8.00m);
            book4.setID(4);
            book4.setTitle("Harry Potter and the Goblet of Fire");

            book5 = new Book(8.00m);
            book5.setID(5);
            book5.setTitle("Harry Potter and the Order of the Phoenix");


            basket = new Basket();
            bookDiscountCalculator = new BookDiscountCalculator();
        }

        [TearDown]
        public void Dispose()
        {
            basket.EmptyBasket();
        }

        [Test]
        public void OneBookCosts8Euros()
        {
            // Arrange
            //Book book = new Book(8.00m);

            // Act
            expected = 8.00m;
            actual = book.getPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // to test more than one book, we will need to have the books collected in some sort of BookCollection
        [Test]
        public void BasketHoldsACollectionOfBooks()
        {
            // Act
            var bookCollection = basket.GetAllBooks();

            // Assert
            Assert.IsInstanceOfType(bookCollection, typeof(List<Book>));
        }

        [Test]
        public void CanAddBooksToBasket()
        {
            // Act
            basket.AddBook(book1);
            basket.AddBook(book2);            

            // Assert
            expected = 2;
            actual = basket.GetAllBooks().Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBooksInBasketHavePrices()
        {   
            // Act
            basket.AddBook(book1);
            basket.AddBook(book2);
            actual = book1.getPrice() + book2.getPrice();
            expected = 16.00m;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfTwoDifferentBooksInBasket()
        {
            // Act
            basket.AddBook(book1);
            basket.AddBook(book2);

            decimal percentageDiscount = 5/100m;
            expected = (1 - percentageDiscount)*16.00m;

            SetActualTotalPrice();
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateTotalPriceMethodWorks()
        {
            // Act
            basket.AddBook(book1);
            basket.AddBook(book2);
            // dont really like depending on the basket existing at this point - should really Mock the basket
            decimal value = bookDiscountCalculator.CalculateTotalPrice(basket);
            
            // Assert
            Assert.IsTrue(basket.GetAllBooks().Count > 0);
            Assert.IsNotNull(value);
            Assert.IsTrue(value >= 0);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfThreeDifferentBooksInBasket()
        {
            decimal percentageDiscount = 10 / 100m;
            expected = (1 - percentageDiscount) * 24.00m;

            basket.AddBook(book1);
            basket.AddBook(book2);
            basket.AddBook(book3);

            Assert.AreEqual(3, basket.GetAllBooks().Count);
            SetActualTotalPrice();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfFourDifferentBooksInBasket()
        {
            decimal percentageDiscount = 20 / 100m;
            expected = (1 - percentageDiscount) * 32.00m;

            basket.AddBook(book1);
            basket.AddBook(book2);
            basket.AddBook(book3);
            basket.AddBook(book4);

            SetActualTotalPrice();

            Assert.AreEqual(4, basket.GetAllBooks().Count);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfFiveDifferentBooksInBasket()
        {
            decimal percentageDiscount = 25 / 100m;
            expected = (1 - percentageDiscount) * 40.00m;
            
            basket.AddBook(book1);
            basket.AddBook(book2);
            basket.AddBook(book3);
            basket.AddBook(book4);
            basket.AddBook(book5);

            SetActualTotalPrice();

            Assert.AreEqual(5, basket.GetAllBooks().Count);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfTwoBooksWhichAreTheSame()
        {
            expected = 16.00m; // feel i dont need to prove i can calculate the discount manually!

            basket.AddBook(book1);
            basket.AddBook(book1);

            SetActualTotalPrice();

            Assert.AreEqual(2, basket.GetAllBooks().Count);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCalculatorToCalculateDiscountOfThreeBooksWhichAreTheSame()
        {
            expected = 24.00m;
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book1);

            SetActualTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        // assume this will work up till 5 books due to time constraint..!
        [Test]
        public void CalculateDiscountOfThreeBooksTwoOfWhichAreTheSame()
        {
            expected = 23.2m;
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book2);

            SetActualTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateDiscountOfFourBooksOnePairFromTwoTitles()
        {
            expected = 30.40m;
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book2);
            basket.AddBook(book2);

            SetActualTotalPrice();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountBooksInBasket()
        {
            basket.AddBook(book1);
            basket.AddBook(book1);

            expected = 2;

            // exemplifying use of properties over traditional transformers and accessors
            actual = basket.NumberOfItems;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDistinctBooksInBasket()
        {
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book2);

            expected = 2;

            // exemplifying use of properties over traditional transformers and accessors
            actual = basket.NumberOfDistinctItems;

            Assert.AreEqual(expected, actual);
        }

        public void CalculateDiscountOfFourBooksThreeOfWhichAreTheSame()
        {
            expected = 31.2m;
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book1);
            basket.AddBook(book2);
        }

        // helpers
        public void SetActualTotalPrice()
        {
            actual = basket.GetTotalPrice(bookDiscountCalculator);
        }
    }
}
//
