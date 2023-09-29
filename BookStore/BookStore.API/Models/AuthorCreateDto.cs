using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class AuthorCreateDto
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]

        public string LastName { get; set; }
        [MaxLength(250)]
        
        public string Bio { get; set; }
    }
}
