using BookStore.API.Models;

namespace BookStore.API.Service.Iservice
{
    public interface IBookService
    {
        Task<IEnumerable<BooksDto>> GetAll();

        Task<BooksDto> GetById(int id);

        Task Delete(int id);

        Task Create(BooksDto booksDto);

        Task Update(int id, BooksDto booksDto);
    }
}
