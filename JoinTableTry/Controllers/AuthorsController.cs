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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService authorService;
        private readonly IRepository<Author> AuthorRepository;
        public AuthorsController(IRepository<Author> AuthorRepository, AuthorService authorService)
        {
            this.authorService = authorService;
            this.AuthorRepository = AuthorRepository;
        }

        [HttpPost(nameof(AddAuthor))]
        public async Task<Object> AddAuthor([FromBody] Author author)
        {
            try
            {
                await authorService.AddAuthor(author);
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete(nameof(DeleteAuthor))]
        public bool DeleteAuthor(int id)
        {
            try
            {
                authorService.DeleteAuthor(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut(nameof(UpdateAuthor))]
        public bool UpdateAuthor(Author author)
        {
            try
            {
                authorService.UpdateAuthor(author);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet(nameof(GetAllAthorsbyName))]
        public Object GetAllAthorsbyName(string name)
        {
            var data = authorService.GetAuthorByName(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet(nameof(GetAllAuthors))]
        public Object GetAllAuthors()
        {
            var data = authorService.GetAllAuthors();
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
