using JoinTableTry.Interface;
using JoinTableTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Service
{
    public class BookService
    {
        private readonly IRepository<Book> book;
        public BookService(IRepository<Book> book)
        {
            this.book = book;
        }
        public IEnumerable<Object> GetBookByAuthor(string name)
        {
            return book.JoinService(name).ToList();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return book.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Book GetBookById(int id)
        {
            return book.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<Book> AddBook(Book book)
        {
            return await this.book.Create(book);
        }
        public void DeleteBook(int id)
        {

            try
            {
                var DataList = book.GetAll().Where(x => x.Id == id).ToList();
                foreach (var item in DataList)
                {
                    book.Delete(item);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void UpdateBook(Book _book)
        {
            try
            {
                var DataList = book.GetAll().ToList();
                foreach (var item in DataList)
                {
                    book.Update(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
