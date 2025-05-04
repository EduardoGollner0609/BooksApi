using BooksApi.Models;

namespace BooksApi.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public AuthorDto() { }

        public AuthorDto(AuthorModel author)
        {
            Id = author.Id;
            Name = author.Name;
            Surname = author.Surname;
        }
    }
}
