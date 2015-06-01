using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace HarryPotterKata.Models
{
    public class Basket : IBookCollection
    {
        private List<Book> Books { get; set; }
        
        // used properties in case I need to set this...YAGNI!??!?
        private int numberOfDistinctItems { get; set; }
        public int NumberOfDistinctItems
        {
            get
            {
                return Books != null ? Books.GroupBy(b => b.GetId()).Count() : 0;
            }
        }

        private int _numberOfItems;
        public int NumberOfItems
        {
            get
            {
                return Books != null ? Books.Count() : 0;
            }
        }
        
        public Basket()
        {
            this.Books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return this.Books;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void EmptyBasket()
        {
            this.Books.Clear();
        }

        // feel the basket doesnt have a calculator but rather is given a calculator to calculate the items inside
        // it also decoupled my basket from my calculator using SRP
        // in hindsight, id probably run each item in the basket through a TillObject which has a Calculator...
        // so maybe there would be a TillObject with a scan method that scans books in this case
        public decimal GetTotalPrice(ICalculator calculator)
        {

            return calculator.CalculateTotalPrice(this);
        }

        public bool Contains(Book book)
        {
            return Books.Contains(book);
        }
    }
}