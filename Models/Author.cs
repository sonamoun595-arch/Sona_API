using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}