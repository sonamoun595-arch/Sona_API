using Microsoft.AspNetCore.Mvc;
using AuthorAPI.Models;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private static List<Author> authors = new()
        {
            new Author
            {
                AuthorId = 1,
                Name = "John Smith",
                Biography = "ASP.NET Developer",
                BirthDate = new DateTime(1990, 5, 20),
                Email = "john@gmail.com"
            },
            new Author
            {
                AuthorId = 2,
                Name = "David Lee",
                Biography = "Software Engineer",
                BirthDate = new DateTime(1995, 8, 10),
                Email = "david@gmail.com"
            }
        };

        // GET: api/author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(authors);
        }

        // GET: api/author/1
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/author
        [HttpPost]
        public ActionResult<Author> CreateAuthor(Author author)
        {
            author.AuthorId = authors.Max(a => a.AuthorId) + 1;

            authors.Add(author);

            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        // PUT: api/author/1
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            var existing = authors.FirstOrDefault(a => a.AuthorId == id);

            if (existing == null)
                return NotFound();

            existing.Name = author.Name;
            existing.Biography = author.Biography;
            existing.BirthDate = author.BirthDate;
            existing.Email = author.Email;

            return NoContent();
        }

        // DELETE: api/author/1
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
                return NotFound();

            authors.Remove(author);

            return NoContent();
        }
    }
}