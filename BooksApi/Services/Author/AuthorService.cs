using BooksApi.Data;
using BooksApi.Dto.Author;
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
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                AuthorModel author = await _context.Authors
                    .FirstOrDefaultAsync(author => author.Id == id);

                if (author == null)
                {
                    response.Message = $"Autor do ID {id} não foi encontrado!";
                    return response;
                }
                response.Datas = author;
                response.Message = $"Autor do ID {id} foi encontrado!";
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> FindByIdBook(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books
                    .Include(x => x.Author)
                    .FirstOrDefaultAsync(book => book.Id == bookId);

                if (book == null)
                {
                    response.Message = $"Livro do ID {bookId} não foi encontrado!";
                    return response;
                }
                AuthorModel author = book.Author;

                response.Datas = author;
                response.Message = $"Autor do livro cujo ID é {bookId} foi localizado com sucesso!";
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> Insert(AuthorInsertDto entity)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                AuthorModel author = new(entity.Name, entity.Surname);
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();

                response.Datas = author;

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
