using System.Text.Json.Serialization;

namespace BooksApi.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<BookModel> Books { get; set; }
        public AuthorModel() { }
        public AuthorModel(int Id)
        {
            Id = Id;
        }

        public AuthorModel(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
