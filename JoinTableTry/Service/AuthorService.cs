using JoinTableTry.Interface;
using JoinTableTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Service
{
    public class AuthorService
    {
        private readonly IRepository<Author> authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public IEnumerable<Object> GetAuthorByName(string name)
        {
            return authorRepository.JoinService(name).ToList();
        }
        public IEnumerable<Author> GetAllAuthors()
        {
            try
            {
                return authorRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Author GetAuthorByName(int id)
        {
            return authorRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<Author> AddAuthor(Author author)
        {
            return await authorRepository.Create(author);
        }
        public void DeleteAuthor(int id)
        {

            try
            {
                var DataList = authorRepository.GetAll().Where(x => x.Id == id).ToList();
                foreach (var item in DataList)
                {
                    authorRepository.Delete(item);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void UpdateAuthor(Author author)
        {
            try
            {
                var DataList = authorRepository.GetAll().ToList();
                foreach (var item in DataList)
                {
                    authorRepository.Update(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
