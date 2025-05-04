using BooksApi.Models;

namespace BooksApi.Repository
{
    public interface ICrudRepository<T, K>
    {
        Task<ResponseModel<List<T>>> FindAll();
        Task<ResponseModel<T>> FindById(int id);
        Task<ResponseModel<T>> Insert(K entity);
        Task<ResponseModel<T>> Update(K entity, int id);
        Task<ResponseModel<T>> DeleteById(int id);
    }
}
