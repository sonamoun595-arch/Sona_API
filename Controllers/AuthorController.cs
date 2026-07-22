using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIApplication.Models;

namespace APIApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private static readonly List<Author> _authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "F. Scott Fitzgerald", Biography = "American novelist.", BirthDate = new DateTime(1896, 9, 24) },
            new Author { AuthorId = 2, Name = "Harper Lee", Biography = "American novelist.", BirthDate = new DateTime(1926, 4, 28) },
            new Author { AuthorId = 3, Name = "George Orwell", Biography = "English novelist.", BirthDate = new DateTime(1903, 6, 25) },
            new Author { AuthorId = 4, Name = "Jane Austen", Biography = "English novelist.", BirthDate = new DateTime(1775, 12, 16) }
        };

        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(_authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var author = _authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            if (author == null) return BadRequest();
            author.AuthorId = _authors.Max(a => a.AuthorId) + 1;
            _authors.Add(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            if (author == null) return BadRequest();
            var existingAuthor = _authors.FirstOrDefault(a => a.AuthorId == id);
            if (existingAuthor == null) return NotFound();

            _authors.Remove(existingAuthor);
            author.AuthorId = id;
            _authors.Add(author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null) return NotFound();

            _authors.Remove(author);
            return Ok(author);
        }
    }
}