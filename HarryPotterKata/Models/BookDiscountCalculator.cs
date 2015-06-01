using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace HarryPotterKata.Models
{
    public class BookDiscountCalculator : ICalculator
    {
        public decimal CalculateTotalPrice(Basket basket)
        {
            return CalculateDiscount(basket) * CalculateSubTotal(basket);
        }

        public decimal CalculateSubTotal(Basket basket)
        {
            return basket.GetAllBooks().Sum(book => book.GetPrice());
        }

        public decimal CalculateDiscount(Basket basket)
        {
            decimal discount = 1;
            int numberOfBooks = basket.NumberOfItems;
            int numberOfDistinctBooks = basket.NumberOfDistinctItems;

            bool condition1 = numberOfDistinctBooks == numberOfBooks;
            bool condition2 = numberOfDistinctBooks == 1;

            // honestly I dont feel I need this anymore after implementing the ComplexBasketDiscount

            if (condition1 || condition2)
            {
                switch (numberOfDistinctBooks)
                {
                    case 1:
                        discount = 0;
                        break;
                    case 2:
                        discount = 5/100m;
                        break;
                    case 3:
                        discount = 10/100m;
                        break;
                    case 4:
                        discount = 20/100m;
                        break;
                    case 5:
                        discount = 25/100m;
                        break;
                    default:
                        discount = 1;
                        break;
                }

                return 1 - discount;

            }
            else
            {
                decimal subTotal = CalculateSubTotal(basket);
                var miniBaskets = CalculateComplicatedBasketCaseDiscount(basket);
                decimal miniBasketsTotalPrice = 0.00m;
                
                foreach (Basket miniBasket in miniBaskets)
                {
                    miniBasketsTotalPrice += (CalculateSubTotal(miniBasket) * CalculateDiscount(miniBasket));
                }

                discount = (subTotal - miniBasketsTotalPrice)/subTotal;
                discount = 1 - discount;
                return discount;
            }
        }

        public List<Basket> CalculateComplicatedBasketCaseDiscount(Basket basket)
        {
            // this will contain a maximum of 5 distinct items or 4 or 3 etc because it doesnt add an item if its already in there.
            var simpleBasketOfBooks = new Basket();

            // each time above basket is full, it is stocked in here
            var simpleBasketOfBooksCollection = new List<Basket>();

            int simpleBasketOfBooksCollectionCount = simpleBasketOfBooksCollection.Sum(b => b.GetAllBooks().Count);

            // have to 'clone' the collection of books because objects are reference types and we will remove items from allBooks later
            var allBooksTemp = new List<Book>();
            foreach (Book book in basket.GetAllBooks())
            {
                allBooksTemp.Add(book);
            }

            while (simpleBasketOfBooksCollectionCount < basket.NumberOfItems)
            {
                foreach (Book book in allBooksTemp)
                {
                    if (!simpleBasketOfBooks.Contains(book))
                    {
                        simpleBasketOfBooks.AddBook(book);
                    }
                }

                simpleBasketOfBooksCollection.Add(simpleBasketOfBooks);
                simpleBasketOfBooksCollectionCount = simpleBasketOfBooksCollection.Sum(b => b.GetAllBooks().Count);
                
                foreach (Book book in simpleBasketOfBooks.GetAllBooks())
                {
                    allBooksTemp.Remove(book);
                }
                simpleBasketOfBooks = new Basket();
                // go round and do it again till the condition is met
            }
            
            return simpleBasketOfBooksCollection;
        }
    }
}