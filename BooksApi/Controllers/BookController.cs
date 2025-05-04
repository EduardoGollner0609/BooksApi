using BooksApi.Dto.Author;
using BooksApi.Dto.Book;
using BooksApi.Models;
using BooksApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<BookDto>>>> FindAll()
        {
            ResponseModel<List<BookDto>> response = await _bookRepository.FindAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<BookDto>>> FindById(int id)
        {
            ResponseModel<BookDto> response = await _bookRepository.FindById(id);
            return Ok(response);
        }

        [HttpGet("Author/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<BookDto>>>> FindByIdAuthor(int authorId)
        {
            ResponseModel<List<BookDto>> response = await _bookRepository.FindByIdAuthor(authorId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<BookDto>>> Insert(BookDto dto)
        {
            ResponseModel<BookDto> response = await _bookRepository.Insert(dto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<BookDto>>> Update(BookDto entity, int id)
        {
            ResponseModel<BookDto> response = await _bookRepository.Update(entity, id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<BookDto>>> Delete(int id)
        {
            ResponseModel<BookDto> response = await _bookRepository.DeleteById(id);
            return Ok(response);
        }
    }
}
