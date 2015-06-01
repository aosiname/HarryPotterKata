using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterKata.Models
{
    public class Book
    {
        private int Id { get; set; }
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
            // s2
        }

        // from a Java OOP origin so I am more comfortable with transformer and accessor over fields and properties
        public string GetTitle()
        {
            return this.Title;
        }
        public decimal GetPrice()
        {
            return this.Price;
        }
        public int GetId()
        {
            return this.Id;
        }


        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}