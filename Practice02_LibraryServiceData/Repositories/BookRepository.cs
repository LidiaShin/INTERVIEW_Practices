using Practice02_LibraryServiceData.Interfaces;
using Practice02_LibraryServiceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice02_LibraryServiceData.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> myBooks = new List<Book>
        {
            new Book{Id = 1, Title = "Paper Son",Author="S.J. Rozan",PublicationYear=2019,CallNumber="S ROZAN"},
            new Book{Id = 2, Title = "In the Midst of winter",Author="isabel allende",PublicationYear=2017,CallNumber="I ALLENDE"},
            new Book{Id = 3, Title = "Ooku",Author="Yoshinaga Humi",PublicationYear=2017,CallNumber="H YOSHINAGA"},
            new Book{Id = 4, Title = "Dogma",Author="Kevin Smith",PublicationYear=1999,CallNumber="S KEVIN"}
        };







        public List<Book> GetAllBooks()
        {
            return myBooks;
        }

        public Book GetBook(int id)
        {
            var book = myBooks.FirstOrDefault(x => x.Id == id);
            return book;
        }
    }
}
