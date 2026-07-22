using Microsoft.AspNetCore.Mvc;
using Sona_API.Models;

namespace Sona_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        // In-memory data
        private static List<Author> authors = new List<Author>()
        {
            new Author().BindAuthor(1, "J.K. Rowling", "Author of Harry Potter", new DateTime(1965, 7, 31)),
            new Author().BindAuthor(2, "George Orwell", "Author of 1984", new DateTime(1903, 6, 25)),
            new Author().BindAuthor(3, "Agatha Christie", "Mystery novelist", new DateTime(1890, 9, 15))
        };

        // GET: api/Author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(authors);
        }

        // GET: api/Author/1
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }

        // POST: api/Author
        [HttpPost]
        public ActionResult<Author> AddAuthor(Author author)
        {
            if (authors.Any(a => a.AuthorId == author.AuthorId))
            {
                return BadRequest("Author ID already exists.");
            }

            authors.Add(author);

            return CreatedAtAction(nameof(GetAuthor),
                new { id = author.AuthorId }, author);
        }

        // PUT: api/Author/1
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author updatedAuthor)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound("Author not found.");
            }

            author.Name = updatedAuthor.Name;
            author.Biography = updatedAuthor.Biography;
            author.BirthDate = updatedAuthor.BirthDate;

            return Ok(author);
        }

        // DELETE: api/Author/1
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound("Author not found.");
            }

            authors.Remove(author);

            return Ok("Author deleted successfully.");
        }
    }
}