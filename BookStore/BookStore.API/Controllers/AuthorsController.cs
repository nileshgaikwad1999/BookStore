using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Filter;
using BookStore.API.Models;
using BookStore.API.Service.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [MyFilterAttribute("AuthorsController")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService) =>_authorService = authorService;
        

        [HttpGet]
        public async Task<IEnumerable<AuthorReadOnlyDto>> Get()  =>  await _authorService.GetAll();
        

        [HttpGet]
        [Route("{id:int}")]
        public async Task<AuthorReadOnlyDto> Get(int id)=> await _authorService.GetById(id);
       

        [HttpPost]
        public async Task Post(AuthorCreateDto authordto)=>await _authorService.Create(authordto);
       

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, AuthorUpdateDto authordto)
        {
            if (id != authordto.Id)
            {
                return BadRequest();
            }

            await _authorService.Update(id, authordto);
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            throw new Exception("user exception");
            await _authorService.Delete(id);
            return NoContent();
        }



    }
}
