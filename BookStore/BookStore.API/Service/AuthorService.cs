using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Repository.IRepository;
using BookStore.API.Service.Iservice;

namespace BookStore.API.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _author;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository author, IMapper mapper)
        {
            _author = author; _mapper = mapper;
        }

        public async Task Create(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            await _author.Inesrt(author);
        }

        public async Task Delete(int id) =>
            await _author.Deletes(id);

        public async Task<IEnumerable<AuthorReadOnlyDto>> GetAll()
        {
            var authors = await _author.getList();
            if(!authors.Any()&&authors.Count()<0)
            {
                throw new Exception("Data Concurrency Exception");
            }
            return _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);
        }

        public async Task<AuthorReadOnlyDto> GetById(int id)
        {
            var authors = await _author.Get(id);
            return _mapper.Map<AuthorReadOnlyDto>(authors);
        }

        public async Task Update(int id, AuthorUpdateDto authorUpdate)
        {
            var author = _mapper.Map<Author>(authorUpdate);
            await _author.Updates(author);
        }
    }
}
