using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sona_API.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }    

        public Author BindAuthor(int authorId, string name, string biography, DateTime birthDate)
        {
            this.AuthorId = authorId;
            this.Name = name;
            this.Biography = biography;
            this.BirthDate = birthDate;
            return this;
        }
    }
}