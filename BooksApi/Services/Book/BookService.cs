using BooksApi.Data;
using BooksApi.Dto;
using BooksApi.Models;
using BooksApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Services.Book
{
    public class BookService : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<BookDto>>> FindAll()
        {
            ResponseModel<List<BookDto>> response = new ResponseModel<List<BookDto>>();
            try
            {
                List<BookModel> books = await _context.Books.Include(book => book.Author).ToListAsync();

                response.Datas = books.Select(book => new BookDto(book)).ToList();
                response.Message = "Livros coletados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookDto>> FindById(int id)
        {
            ResponseModel<BookDto> response = new ResponseModel<BookDto>();
            try
            {
                BookModel book = await _context.Books
                    .Include(book => book.Author)
                    .FirstOrDefaultAsync(book => book.Id == id);

                if (book == null)
                {
                    response.Message = $"Livro do ID {id} não foi encontrado!";
                    return response;
                }

                response.Datas = new BookDto(book);
                response.Message = $"Livro do ID {id} localizado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookDto>>> FindByIdAuthor(int authorId)
        {
            ResponseModel<List<BookDto>> response = new ResponseModel<List<BookDto>>();
            try
            {
                List<BookModel> books = await _context.Books
                    .Include(book => book.Author)
                    .Where(book => book.Author.Id == authorId)
                    .ToListAsync();

                response.Datas = books.Select(book => new BookDto(book)).ToList();
                response.Message = $"Livros que pertencem ao autor do ID {authorId} foi encontrado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookDto>> Insert(BookDto entity)
        {
            ResponseModel<BookDto> response = new ResponseModel<BookDto>();
            try
            {
                AuthorModel author = await _context.Authors.
                    FirstOrDefaultAsync(author => author.Id == entity.Author.Id);

                if (author == null)
                {
                    response.Message = $"Autor do ID {entity.Author.Id} não foi localizado!";
                    return response;
                }

                BookModel book = new(entity.Title, author);

                _context.Add(book);
                await _context.SaveChangesAsync();

                response.Datas = new BookDto(book);

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookDto>> Update(BookDto entity, int id)
        {
            ResponseModel<BookDto> response = new ResponseModel<BookDto>();
            try
            {
                BookModel book = await _context.Books
                    .Include(book => book.Author)
                    .FirstOrDefaultAsync(book => book.Id == id);

                AuthorModel author = await _context.Authors.
                   FirstOrDefaultAsync(author => author.Id == entity.Author.Id);

                if (book == null)
                {
                    response.Message = $"Livro do ID {id} não foi encontrado!";
                    return response;
                }
                if (author == null)
                {
                    response.Message = $"Autor do ID {id} não foi encontrado!";
                    return response;
                }

                book.Title = entity.Title;
                book.Author = author;

                _context.Update(book);
                await _context.SaveChangesAsync();

                response.Datas = new BookDto(book);
                response.Message = $"Livro do ID {id} foi atualizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookDto>> DeleteById(int id)
        {
            ResponseModel<BookDto> response = new ResponseModel<BookDto>();
            try
            {
                BookModel book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);

                if (book == null)
                {
                    response.Message = $"Livro do ID {id} não foi encontrado!";
                    return response;
                }

                _context.Remove(book);
                await _context.SaveChangesAsync();

                response.Message = $"Livro do ID {id} foi deletado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
