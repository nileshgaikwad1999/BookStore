namespace BookStore.API.Models
{
    public class BooksDto:BaseDto
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string IsBn { get; set; } 
        public string Summary { get; set;}
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int? AuthorId { get; set; }
    }
}
