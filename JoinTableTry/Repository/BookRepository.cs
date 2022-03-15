using JoinTableTry.Data;
using JoinTableTry.Interface;
using JoinTableTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Repository
{
    public class BookRepository:IRepository<Book>
    {
        LibraryContext libraryContext;
        public BookRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<Book> Create(Book book)
        {
            var _book = await libraryContext.Books.AddAsync(book);
            libraryContext.SaveChanges();
            return _book.Entity;
        }

        public void Delete(Book book)
        {
            libraryContext.Books.Remove(book);
            libraryContext.SaveChanges();
            
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                return libraryContext.Books.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Book GetById(int Id)
        {
            return libraryContext.Books.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Object> JoinService(string name)
        {
               var q = libraryContext.Authors.Join(libraryContext.Books, x => x.Name, y => y.AuthorName, (x, y) => new
            {
                x.Name,
                y.AuthorName,
                y.Genre,
                y.Title,
                y.Year,
                y.Price
            }).ToList();
            return q;
        }

        public void Update(Book book)
        {
            libraryContext.Books.Update(book);
            libraryContext.SaveChanges();
        }
    }
}
