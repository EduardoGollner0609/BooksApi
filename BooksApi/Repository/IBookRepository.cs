using BooksApi.Dto;
using BooksApi.Models;

namespace BooksApi.Repository
{
    public interface IBookRepository : ICrudRepository<BookDto>
    {
        Task<ResponseModel<List<BookDto>>> FindByIdAuthor(int authorId);
    }
}
