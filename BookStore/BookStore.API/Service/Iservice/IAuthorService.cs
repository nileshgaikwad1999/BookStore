using BookStore.API.Models;

namespace BookStore.API.Service.Iservice
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadOnlyDto>> GetAll();

        Task<AuthorReadOnlyDto> GetById(int id);

        Task Delete(int id);

        Task Create(AuthorCreateDto authorCreateDto);

        Task Update(int id,AuthorUpdateDto authorUpdate);

    }
}
