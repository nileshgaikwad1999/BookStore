using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Service.Iservice
{
    public interface ISpBookService
    {
        public Task<List<BooksDto>> Getall();

        public Task Insert(CreateAuthorAndBook iteam);

        public Task Update(CreateAuthorAndBook iteam);


    }

}
