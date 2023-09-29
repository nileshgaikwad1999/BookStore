using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Repository.IRepository;
using BookStore.API.Service.Iservice;
using Microsoft.Data.SqlClient;
using System.IO;

namespace BookStore.API.Service
{
    public class SpBookService : ISpBookService
    {
        private readonly ISPBookRepository _sPBookRepository;
        private readonly IMapper _mapper;

        public SpBookService(ISPBookRepository sPBookRepository, IMapper mapper)
        {
            _sPBookRepository = sPBookRepository;
            _mapper= mapper;
        }

        public async Task<List<BooksDto>> Getall()
        {
            var data=await _sPBookRepository.GetAllBooks();

            return _mapper.Map<List<BooksDto>>(data);
        }

        public async Task Insert(CreateAuthorAndBook iteam)
        {
            var data=_mapper.Map<AuthorBook>(iteam);
            await  _sPBookRepository.Insert(data);
        }

        public async Task Update(CreateAuthorAndBook iteam)
        {
            var data = _mapper.Map<AuthorBook>(iteam);
            await _sPBookRepository.Update(data);
        }

   
    }
}
