using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterKata.Models
{
    public class Basket : IBookCollection
    {
        private List<Book> books { get; set; }
        
        // used properties in case I need to set this...YAGNI!??!?
        private int numberOfDistinctItems { get; set; }
        public int NumberOfDistinctItems
        {
            get
            {
                return books != null ? books.GroupBy(b => b.getID()).Count() : 0;
            }
        }

        private int numberOfItems;
        public int NumberOfItems
        {
            get
            {
                return books != null ? books.Count() : 0;
            }
        }
        
        public Basket()
        {
            this.books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return this.books;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void EmptyBasket()
        {
            this.books.Clear();
        }

        public decimal GetTotalPrice(ICalculator calculator)
        {

            return calculator.CalculateTotalPrice(this);
        }



        
    }
}