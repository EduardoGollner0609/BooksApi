using BooksApi.Dto.Author;
using BooksApi.Models;
using BooksApi.Repository;

namespace BooksApi.Services.Author
{
    public interface IAuthorInterface : ICrudRepository<AuthorModel, AuthorInsertDto>
    {
        Task<ResponseModel<AuthorModel>> FindByIdBook(int bookId);
    }
}
