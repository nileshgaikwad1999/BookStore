using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly booksAppContext _context;


        public AuthorRepository(booksAppContext booksAppContext)
        {
            _context = booksAppContext;
        }
        public async Task Deletes(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                throw new Exception();
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Author>> getList()
        {
            var data = await _context.Authors.ToListAsync();
            return data;
        }

        public async Task<Author> Get(int id)
        {
            var data = await _context.Authors.Where(e => e.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Inesrt(Author item)
        {
            _context.Authors.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Updates(Author item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
