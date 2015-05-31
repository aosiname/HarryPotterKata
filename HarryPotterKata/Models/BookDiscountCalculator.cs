using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace HarryPotterKata.Models
{
    public class BookDiscountCalculator : ICalculator
    {
        public int CalculateBookDiscount(List<Book> books)
        {
            // get distinct number of books
            var distinct = books.DistinctBy(b => b.getID());

            // sort books by book id

            // form a BookLine of size (distinct number) - this is the max size of any line
            Book[] line = new Book[distinct.Count()];
            // create a collection of lines

            // loop books

            // if not in line (by id) add to line

            // if 

            /*
               2 3 4 5 20
             1 2 3 4 5 25
             1 2 3 4 5 25
             1   3 4   10
               2   4 5 10
                 3 4   05
             1       5 05
        
             
             1 2 3 4 5 25 = 30.00
             1 2 3     10 = 21.60
                            -----
                            51.60
             
             */
            return 0;
        }


        public decimal CalculateTotalPrice(Basket basket)
        {
            return CalculateDiscount(basket) * CalculateSubTotal(basket);
        }

        public decimal CalculateSubTotal(Basket basket)
        {
            return basket.GetAllBooks().Sum(book => book.getPrice());
        }

        public decimal CalculateDiscount(Basket basket)
        {
            decimal discount = 1;

            // feel basket should return this.
            // int numberOfBooks = basket.GetAllBooks().Count;
            int numberOfBooks = basket.NumberOfItems;
            int numberOfDistinctBooks = basket.NumberOfDistinctItems;


            //https://github.com/dchetwynd/Harry-Potter-Kata/blob/master/potterkata.py (inspiration)


            // only continue down here if
            bool condition1 = numberOfDistinctBooks == numberOfBooks;
            bool condition2 = numberOfDistinctBooks == 1;
            //bool condition3 = numberOfBooks % numberOfDistinctBooks == 0;

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
                //throw new Exception("complicated basket case");

                // I reckon I can biologically dissect the complicated basket 
                // send it back into this method - by which time, it should be 
                // able to get a value for the discount

                // supposed price = number of items in basket x 8
                decimal subTotal = CalculateSubTotal(basket);


                // actual price = for each mini basket in the complicated basket
                // calculate the price with the discount
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
            // this will contain a max of 5 distinct items or 4 or 3 etc
            var simpleBasketOfBooks = new Basket();

            // each time above is full, it is placed in here
            var simpleBasketOfBooksCollection = new List<Basket>();


            int simpleBasketOfBooksCollectionCount = simpleBasketOfBooksCollection.Sum(b => b.GetAllBooks().Count);

            var allBooks = new List<Book>();
            foreach (Book book in basket.GetAllBooks())
            {
                allBooks.Add(book);
            }

            int allBooksCount = basket.NumberOfItems;


            while (simpleBasketOfBooksCollectionCount < allBooksCount)
            {
                foreach (Book book in allBooks)
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
                    allBooks.Remove(book);
                }
                simpleBasketOfBooks = new Basket();
                // go round and do it again till the condition is met
            }


            
            return simpleBasketOfBooksCollection;
        }


        public int simpleBasketCollectionCountAll(List<Basket> collection )
        {
            return collection.Sum(basket => basket.GetAllBooks().Count);
        }
    }
}