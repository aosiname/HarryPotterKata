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
            switch (basket.GetAllBooks().GroupBy(b => b.getID()).Count())
            {
                case 1 :
                    discount = 0;
                    break;
                case 2:
                    discount = 5 / 100m;
                    break;
                case 3:
                    discount = 10 / 100m;
                    break;
                case 4:
                    discount = 20 / 100m;
                    break;
                case 5:
                    discount = 25 / 100m;
                    break;
                default:
                    discount = 1;
                    break;
            }

            return 1 - discount;
        }
    }
}