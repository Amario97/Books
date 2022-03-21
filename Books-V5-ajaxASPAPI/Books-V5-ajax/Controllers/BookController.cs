using Books_V5_ajax.Models;
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
        // GET api/<controller>      GET data
        [HttpGet]
        public IEnumerable<Book> getAllBooks()
        {
            //return books;
            return WebApiConfig.myList;
        }

        // GET api/<controller>/5     GET specific data
        public IHttpActionResult GetNote(string id)
        {
            Book foundBook = WebApiConfig.myList.FirstOrDefault((p) => p.Id == id);
            if (foundBook == null)
            {
                return NotFound();
            }
            return Ok(foundBook);
        }

        // POST api/<controller>     Post new data
        [HttpPost]
        public string AddBook(Book newBook)
        {
            WebApiConfig.myList.Add(newBook);
            return newBook.Title;
        }

        // PUT api/<controller>/5   PUT updated data 
        //public void Put(int id, [FromBody] string value)
        public IHttpActionResult Put(string id, [FromBody]Book updatedBook)
        {
            for (int i = 0; i < WebApiConfig.myList.Count; i++)
            {
                if (id == WebApiConfig.myList[i].Id)
                {
                    WebApiConfig.myList[i] = updatedBook;
                    //WebApiConfig.myList.RemoveAt(i);
                    //WebApiConfig.myList.Add(Book value)

                    return Ok("Book with ID " + id + " updated");
                }
            }
            return NotFound();
        }

        // DELETE api/<controller>/3  DELETE some data
        [HttpDelete]
        public IHttpActionResult DELETE(string id)   
        {
            for (int i = 0; i < WebApiConfig.myList.Count; i++)
            {
                if (id == WebApiConfig.myList[i].Id)
                {
                    WebApiConfig.myList.RemoveAt(i);
                    return Ok("Book with ID " + id + " removed");
                }
            }

            return NotFound();
        }
    }
}