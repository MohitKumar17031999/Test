using JoinTableTry.Interface;
using JoinTableTry.Models;
using JoinTableTry.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BookService bookService;
        private readonly IRepository<Book> BookRepository;
        public LibraryController(IRepository<Book> BookRepository,BookService bookService )
        {
            this.bookService = bookService;
            this.BookRepository = BookRepository;
        }

        [HttpPost(nameof(AddBook))]
        public async Task<Object> AddBook([FromBody] Book book)
        {
            try
            {
                await bookService.AddBook(book);
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete(nameof(DeleteBook))]
        public bool DeleteBook(int id)
        {
            try
            {
                bookService.DeleteBook(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut(nameof(UpdateBook))]
        public bool UpdateBook(Book book)
        {
            try
            {
                bookService.UpdateBook(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet(nameof(GetAllBooksByYear))]
        public Object GetAllBooksByYear(string name)
        {
            var data = bookService.GetBookByAuthor(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet(nameof(GetAllBooks))]
        public Object GetAllBooks()
        {
            var data = bookService.GetAllBooks();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
