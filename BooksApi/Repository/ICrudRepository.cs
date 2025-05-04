using BooksApi.Models;

namespace BooksApi.Repository
{
    public interface ICrudRepository<T>
    {
        Task<ResponseModel<List<T>>> FindAll();
        Task<ResponseModel<T>> FindById(int id);
        Task<ResponseModel<T>> Insert(T entity);
        Task<ResponseModel<T>> Update(T entity, int id);
        Task<ResponseModel<T>> DeleteById(int id);
    }
}
