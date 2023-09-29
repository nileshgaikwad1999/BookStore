using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Repository.IRepository;
using BookStore.API.Service.Iservice;

namespace BookStore.API.Service
{
    public class BookService : IBookService
    {

        private readonly IBookRepositroy _bookRepositroy;
        private readonly IMapper _mapper;

        public BookService(IBookRepositroy bookRepositroy, IMapper mapper)
        {
            _bookRepositroy = bookRepositroy;
            _mapper = mapper;
        }

        public async Task Create(BooksDto booksDto)
        {
            var book = _mapper.Map<Book>(booksDto);
            await _bookRepositroy.Inesrt(book);
        }

        public async Task Delete(int id)
        {
            await _bookRepositroy.Deletes(id);
        }

        public async Task<IEnumerable<BooksDto>> GetAll()
        {
            var books = await _bookRepositroy.getList();
            return _mapper.Map<IEnumerable<BooksDto>>(books);
        }

        public async Task<BooksDto> GetById(int id)
        {
            var book = await _bookRepositroy.Get(id);
            return _mapper.Map<BooksDto>(book);
        }

        public async Task Update(int id, BooksDto booksDto)
        {
            var book = _mapper.Map<Book>(booksDto);
            await _bookRepositroy.Updates(book);
        }
    }
}
