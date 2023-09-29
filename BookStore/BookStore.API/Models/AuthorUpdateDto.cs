namespace BookStore.API.Models
{
    public class AuthorUpdateDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}
