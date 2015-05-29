using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterKata.Models
{
    interface IBookCollection
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        void RemoveBook(Book book);
        void EmptyBasket();
    }
}
