using BooksApi.Models;

namespace BooksApi.Repository
{
    public interface ICrudRepository<T>
    {
        Task<ResponseModel<List<T>>> FindAll();
        Task<ResponseModel<T>> FindById(int id);
    }
}
