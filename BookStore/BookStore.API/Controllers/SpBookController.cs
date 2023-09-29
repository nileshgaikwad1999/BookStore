using BookStore.API.Models;
using BookStore.API.Service.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpBookController : ControllerBase
    {
        public ISpBookService SpBook;

        public SpBookController(ISpBookService spBook)
        {
            SpBook = spBook;
        }
        [HttpGet]
        public async Task<List<BooksDto>> GetBooks()
        {
           return await SpBook.Getall();
        }

        [HttpPost]
        public async Task Post(CreateAuthorAndBook create)
        {
           await SpBook.Insert(create);
        }
        [HttpPut]
        public async Task Put(CreateAuthorAndBook create)
        {
            await SpBook.Update(create);
        }

      
    }
}
