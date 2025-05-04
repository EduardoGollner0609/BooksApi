using BooksApi.Dto;
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
            if (response.Datas == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("Book/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> FindByIdBook(int bookId)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.FindByIdBook(bookId);
            if (response.Datas == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Insert(AuthorDto dto)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.Insert(dto);

            var uri = $"{Request.Scheme}://{Request.Host}{Request.Path}/{response.Datas.Id}";

            return Created(uri, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Update(AuthorDto entity, int id)
        {
            ResponseModel<AuthorDto> response = await _authorRepository.Update(entity, id);
            if (response.Datas == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorDto>>> Delete(int id)
        {
            string messageNotFound = $"Autor do ID {id} não foi encontrado!";
            ResponseModel<AuthorDto> response = await _authorRepository.DeleteById(id);
            if (response.Message.Equals(messageNotFound))
            {
                return NotFound(response);
            }
            return NoContent();
        }
    }
}
