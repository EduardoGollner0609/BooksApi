using BooksApi.Data;
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Services.Author
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<AuthorModel>>> FindAll()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                List<AuthorModel> authors = await _context.Authors.ToListAsync();

                response.Datas = authors;
                response.Message = "Todos os Autores foram coletados!";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> FindById(int id)
        {
         
        }

        public Task<ResponseModel<AuthorModel>> FindByIdBook(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
