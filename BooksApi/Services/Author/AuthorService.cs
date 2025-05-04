using Azure;
using BooksApi.Data;
using BooksApi.Dto;
using BooksApi.Models;
using BooksApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Services.Author
{
    public class AuthorService : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<AuthorDto>>> FindAll()
        {
            ResponseModel<List<AuthorDto>> response = new ResponseModel<List<AuthorDto>>();
            try
            {
                List<AuthorModel> authors = await _context.Authors.ToListAsync();

                response.Datas = authors.Select(author => new AuthorDto(author)).ToList();
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

        public async Task<ResponseModel<AuthorDto>> FindById(int id)
        {
            ResponseModel<AuthorDto> response = new ResponseModel<AuthorDto>();
            try
            {
                AuthorModel author = await _context.Authors
                    .FirstOrDefaultAsync(author => author.Id == id);

                if (author == null)
                {
                    response.Message = $"Autor do ID {id} não foi encontrado!";
                    return response;
                }
                response.Datas = new AuthorDto(author);
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

        public async Task<ResponseModel<AuthorDto>> FindByIdBook(int bookId)
        {
            ResponseModel<AuthorDto> response = new ResponseModel<AuthorDto>();
            try
            {
                BookModel book = await _context.Books
                    .Include(x => x.Author)
                    .FirstOrDefaultAsync(book => book.Id == bookId);

                if (book == null)
                {
                    response.Message = $"Livro do ID {bookId} não foi encontrado!";
                    return response;
                }
                AuthorModel author = book.Author;

                response.Datas = new AuthorDto(author);
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

        public async Task<ResponseModel<AuthorDto>> Insert(AuthorDto entity)
        {
            ResponseModel<AuthorDto> response = new ResponseModel<AuthorDto>();
            try
            {
                AuthorModel author = new(entity.Name, entity.Surname);
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();

                response.Datas = new AuthorDto(author);

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorDto>> Update(AuthorDto entity, int id)
        {
            ResponseModel<AuthorDto> response = new ResponseModel<AuthorDto>();
            try
            {
                AuthorModel author = await _context.Authors.
                    FirstOrDefaultAsync(author => author.Id == id);

                if (author == null)
                {
                    response.Message = $"Autor do ID {id} não foi encontrado!";
                    return response;
                }

                author.Name = entity.Name;
                author.Surname = entity.Surname;

                _context.Update(author);
                await _context.SaveChangesAsync();

                response.Datas = new AuthorDto(author);
                response.Message = $"Autor do ID {id} atualizado com sucesso!";
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorDto>> DeleteById(int id)
        {
            ResponseModel<AuthorDto> response = new ResponseModel<AuthorDto>();
            try
            {
                AuthorModel author = await _context.Authors.
                    FirstOrDefaultAsync(author => author.Id == id);

                if (author == null)
                {
                    response.Message = $"Autor do ID {id} não foi encontrado!";
                    return response;
                }

                _context.Remove(author);
                await _context.SaveChangesAsync();

                response.Message = "Deletado com sucesso!";
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
