//using Books_V5_ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books_V5_ajax.Controllers
{
    public class BookController : ApiController
    {
        BookModelContainer myBooks = new BookModelContainer();

        // GET api/<controller>      GET data
        [HttpGet]
        public IEnumerable<Book> getAllBooks()
        {
            return myBooks.Books.ToList();
        }

        // GET api/<controller>/5     GET specific data
        public IHttpActionResult GetBook(string id)
        {
            try
            {
                int intId = Convert.ToInt32(id);
                var getBook = (from oneBook in myBooks.Books
                               where oneBook.BookId == intId
                               select oneBook).First();
                return Ok(getBook);
            }
            catch (Exception)
            {
                return NotFound(); ;
            }
          
        }

        // POST api/<controller>     Post new data
        [HttpPost]
        public string AddBook(Book newBook)
        {
            myBooks.Books.Add(newBook);
            myBooks.SaveChanges();
            return newBook.Title;
        }

        // PUT api/<controller>/5   PUT updated data 
        public IHttpActionResult Put(string id, [FromBody] Book updatedBook)
        {
            try
            {
                int intId = Convert.ToInt32(id);
                var bookToChange = (from oneBook in myBooks.Books
                                    where oneBook.BookId == intId
                                    select oneBook).First();
                Book theOne = bookToChange;

                theOne.Title = updatedBook.Title;
                theOne.Genre = updatedBook.Genre;
                theOne.Year = updatedBook.Year;
                theOne.Author = updatedBook.Author;
                myBooks.SaveChanges();
                return Ok("Book with ID " + id + " updated");
            }
            catch (Exception)
            {
                return NotFound();
            }
           
        }

        // DELETE api/<controller>/3  DELETE some data
        [HttpDelete]
        public IHttpActionResult DELETE(string id)
        {
            try
            {
                int intId = Convert.ToInt32(id);
                var bookToDelete = (from oneBook in myBooks.Books
                                    where oneBook.BookId == intId
                                    select oneBook).First();
                Book thisOne = bookToDelete;

                myBooks.Books.Remove(thisOne);
                myBooks.SaveChanges();
                return Ok("Book with ID " + id + " removed");
            }
            catch (Exception)
            {
                return NotFound();
            }
           
        }
    }
}