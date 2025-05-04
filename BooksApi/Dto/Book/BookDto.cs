using BooksApi.Models;

namespace BooksApi.Dto.Book
{
    public class BookDto
    {
        public string Title { get; set; }
        public AuthorModel Author { get; set; }
    }
}
