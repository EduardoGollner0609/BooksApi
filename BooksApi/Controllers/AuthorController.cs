using BooksApi.Dto.Author;
using BooksApi.Models;
using BooksApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<AuthorDto>>>> FindAll()
        {
            ResponseModel<List<AuthorDto>> response = await _authorRepository.FindAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> FindById(int id)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.FindById(id);
            return Ok(response);
        }

        [HttpGet("Book/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> FindByIdBook(int bookId)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.FindByIdBook(bookId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Insert(AuthorDto dto)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.Insert(dto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Update(AuthorDto entity, int id)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.Update(entity, id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Delete(int id)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.DeleteById(id);
            return Ok(response);
        }
    }
}
