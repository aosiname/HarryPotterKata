using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterKata.Models
{
    public class Book
    {
        private int ID { get; set; }
        private string Title { get; set; }
        private decimal Price { get; set; }

        public Book(decimal defaultPrice)
        {
            // felt it was better to push default through ctor rather than hardcode it (inverting the control to the caller)
            this.Price = defaultPrice;
        }

        public Book()
        {
            // TODO: Complete member initialization
        }

        // from a Java OOP origin so I am more comfortable with transformer and accessor over fields and properties
        public string getTitle()
        {
            return this.Title;
        }
        public decimal getPrice()
        {
            return this.Price;
        }
        public int getID()
        {
            return this.ID;
        }


        public void setTitle(string title)
        {
            this.Title = title;
        }

        public void setID(int id)
        {
            this.ID = id;
        }
    }
}