using BooksApi.Dto.Author;
using BooksApi.Models;

namespace BooksApi.Dto.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }

        public BookDto() { }
        public BookDto(BookModel book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = new AuthorDto(book.Author);
        }
    }
}
