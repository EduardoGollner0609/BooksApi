using BooksApi.Dto;
using BooksApi.Models;
using BooksApi.Repository;
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
            if (response.Datas == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("Author/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<BookDto>>>> FindByIdAuthor(int authorId)
        {
            string messageNotFoundAuthor = $"Livro do ID {authorId} não foi encontrado!";
            ResponseModel<List<BookDto>> response = await _bookRepository.FindByIdAuthor(authorId);
            if (response.Datas.Equals(messageNotFoundAuthor))
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<BookDto>>> Insert(BookDto dto)
        {
            ResponseModel<BookDto> response = await _bookRepository.Insert(dto);
            if (response.Datas == null)
            {
                return NotFound(response);
            }

            var uri = $"{Request.Scheme}://{Request.Host}{Request.Path}/{response.Datas.Id}";

            return Created(uri, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<BookDto>>> Update(BookDto entity, int id)
        {
            ResponseModel<BookDto> response = await _bookRepository.Update(entity, id);
            if (response.Datas == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<BookDto>>> Delete(int id)
        {
            string messageNotFound = $"Livro do ID {id} não foi encontrado!";
            ResponseModel<BookDto> response = await _bookRepository.DeleteById(id);
            if (response.Message.Equals(messageNotFound))
            {
                return NotFound(response);
            }
            return NoContent();
        }
    }
}
