using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Filter;
using BookStore.API.Models;
using BookStore.API.Service.Iservice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [MyAsycFilterAttribute]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService book)
        {
           _bookService= book;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BooksDto>> Get()
        {
            return await _bookService.GetAll();
        }

      
        [HttpGet("{id}")]
        public async Task<BooksDto> Get(int id)
        {
          return await _bookService.GetById(id);
        }

        [HttpPost]
        public async Task Post(BooksDto books)
        {
           await _bookService.Create(books);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BooksDto books)
        {
            await _bookService.Update(id, books);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
         await  _bookService.Delete(id);
        }
    }
}
