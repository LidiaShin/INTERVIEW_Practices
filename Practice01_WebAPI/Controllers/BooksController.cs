using Practice01_WebAPI.Models;
using Practice02_LibraryServiceData.Interfaces;
using Practice02_LibraryServiceData.Models;
using Practice02_LibraryServiceData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice01_WebAPI.Controllers
{
    public class BooksController : ApiController
    {

        //private IBookRepository books = new BookRepository();
        private IBookRepository books;

        public BooksController(IBookRepository _books)
        {
            this.books = _books;
        }



        // GET api/Book
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        // GET api/Book/2
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
