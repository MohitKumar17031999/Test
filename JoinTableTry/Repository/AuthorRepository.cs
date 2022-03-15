using JoinTableTry.Data;
using JoinTableTry.Interface;
using JoinTableTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        LibraryContext libraryContext;
        public AuthorRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }
        public async Task<Author> Create(Author author)
        {
            var _author = await libraryContext.Authors.AddAsync(author);
            libraryContext.SaveChanges();
            return _author.Entity;
        }

        public void Delete(Author author)
        {
            libraryContext.Authors.Remove(author);
            libraryContext.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                return libraryContext.Authors.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        public IEnumerable<Object> JoinService(string name)
        {
            var q = (from bookData in libraryContext.Books
                     join authorData in libraryContext.Authors on bookData.AuthorName equals name

                     select new
                     {
                         bookData.Id,
                         bookData.Title,
                         bookData.Genre,
                         bookData.Year,
                         bookData.Price,
                         authorData.Name,
                       
                     }).ToList();
            return q;

        }
        public Author GetById(int Id)
        {
            return libraryContext.Authors.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Author author)
        {
            libraryContext.Authors.Update(author);
            libraryContext.SaveChanges();
        }
    }
}
