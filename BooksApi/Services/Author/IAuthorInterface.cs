using BooksApi.Models;
using BooksApi.Repository;

namespace BooksApi.Services.Author
{
    public interface IAuthorInterface : ICrudRepository<AuthorModel>
    {
        Task<ResponseModel<AuthorModel>> FindByIdBook(int bookId);
    }
}
