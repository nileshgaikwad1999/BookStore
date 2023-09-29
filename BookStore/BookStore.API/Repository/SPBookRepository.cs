using BookStore.API.Data;
using BookStore.API.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace BookStore.API.Repository
{
    public class SPBookRepository : ISPBookRepository
    {
        private readonly booksAppContext _context;

        public SPBookRepository(booksAppContext context)
        {
            _context = context;
        }
        public async Task<List<BooksDetails>> GetAllBooks()
        {
           var data=await _context.booksDetails.FromSqlRaw("sp_FetchBookDetails").ToListAsync();
            return data;
         }

        public async Task Insert(AuthorBook author)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@firstName", author.FirstName));
            param.Add(new SqlParameter("@lastName", author.LastName));
            param.Add(new SqlParameter("@bio", author.Bio));
            param.Add(new SqlParameter("@title", author.Books.Title));
            param.Add(new SqlParameter("@year", author.Books.Year));
            param.Add(new SqlParameter("@isbtn", author.Books.IsBn));
            param.Add(new SqlParameter("@summary", author.Books.Summary));
            param.Add(new SqlParameter("@image", author.Books.Image));
            param.Add(new SqlParameter("@price",Convert.ToInt32(author.Books.Price)));
           await _context.Database.ExecuteSqlRawAsync("Sp_InsertAuthAndBook @firstName,@lastName,@bio,@title,@year,@isbtn,@summary,@image,@price", param.ToArray());
        }
      public async Task Update(AuthorBook author)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id", author.Id));
            param.Add(new SqlParameter("@firstName", author.FirstName));
            param.Add(new SqlParameter("@lastName", author.LastName));
            param.Add(new SqlParameter("@bio", author.Bio));
            param.Add(new SqlParameter("@title", author.Books.Title));
            param.Add(new SqlParameter("@year", author.Books.Year));
            param.Add(new SqlParameter("@isbtn", author.Books.IsBn));
            param.Add(new SqlParameter("@summary", author.Books.Summary));
            param.Add(new SqlParameter("@image", author.Books.Image));
            param.Add(new SqlParameter("@price", Convert.ToInt32(author.Books.Price)));
            param.Add(new SqlParameter("@Authid", author.Books.AuthorId));
            await _context.Database.ExecuteSqlRawAsync("SP_UpdateAuthAndBook @id, @firstName,@lastName,@bio,@title,@year,@isbtn,@summary,@image,@price,@Authid", param.ToArray());
        }

    }
   
}
