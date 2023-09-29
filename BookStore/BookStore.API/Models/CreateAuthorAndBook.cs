namespace BookStore.API.Models
{
    public class CreateAuthorAndBook
    {
        public AuthorCreateDto AuthorCreateDto { get; set; }

        public BooksDto BooksDto { get; set; }
    }
}
