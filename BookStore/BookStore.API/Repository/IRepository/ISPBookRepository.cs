using BookStore.API.Data;

namespace BookStore.API.Repository.IRepository
{
    public interface ISPBookRepository
    {
        Task<List<BooksDetails>> GetAllBooks();
        Task Insert(AuthorBook author);

        Task Update(AuthorBook author);

    }
}
