using BookStore.API.Data;
using BookStore.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepositroy
    {
        public booksAppContext _context;
        public BookRepository(booksAppContext context)
        {
            _context = context;
        }
        public async Task Deletes(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.Include(e => e.Author).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Book>> getList()
        {
            return await _context.Books.Include(e=>e.Author).ToListAsync();
        }

        public async Task Inesrt(Book item)
        {
            _context.Books.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Updates(Book item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
