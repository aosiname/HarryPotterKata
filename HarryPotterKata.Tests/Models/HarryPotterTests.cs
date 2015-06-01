using System;
using HarryPotterKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace HarryPotterKata.Tests.Models
{
    [TestClass]
    public class HarryPotterTests
    {
        protected Book Book, Book1, Book2, Book3, Book4, Book5;
        protected object Expected, Actual;
        protected Basket Basket;
        protected BookDiscountCalculator BookDiscountCalculator;

        [SetUp]
        public void Init()
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
            Book = new Book(8.00m);

            Book1 = new Book(8.00m);
            Book1.SetId(1);
            Book1.SetTitle("Harry Potter and the Philosopher's Stone");

            Book2 = new Book(8.00m);
            Book2.SetId(2);
            Book2.SetTitle("Harry Potter and the Chamber of Secrets");

            Book3 = new Book(8.00m);
            Book3.SetId(3);
            Book3.SetTitle("Harry Potter and the Prisoner of Azkaban");

            Book4 = new Book(8.00m);
            Book4.SetId(4);
            Book4.SetTitle("Harry Potter and the Goblet of Fire");

            Book5 = new Book(8.00m);
            Book5.SetId(5);
            Book5.SetTitle("Harry Potter and the Order of the Phoenix");


            Basket = new Basket();
            BookDiscountCalculator = new BookDiscountCalculator();
        }

        [TearDown]
        public void Dispose()
        {
            Basket.EmptyBasket();
        }

        // helpers
        public void SetActualTotalPrice()
        {
            Actual = Basket.GetTotalPrice(BookDiscountCalculator);
        }

        public decimal RoundDecimalToXdp(decimal subject, int decimalPlaces)
        {
            return Math.Round(subject, decimalPlaces, MidpointRounding.AwayFromZero);
        }
    }
}
