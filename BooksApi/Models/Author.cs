using System.Text.Json.Serialization;

namespace BooksApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
