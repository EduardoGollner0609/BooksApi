using BooksApi.Dto.Author;
using BooksApi.Models;
using BooksApi.Services.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> FindAll()
        {
            ResponseModel<List<AuthorModel>> response = await _authorInterface.FindAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindById(int id)
        {
            ResponseModel<AuthorModel> response = await _authorInterface.FindById(id);
            return Ok(response);
        }

        [HttpGet("Book/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindByIdBook(int bookId)
        {
            ResponseModel<AuthorModel> response = await _authorInterface.FindByIdBook(bookId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> Insert(AuthorInsertDto dto)
        {
            ResponseModel<AuthorModel> author = await _authorInterface.Insert(dto);
            return Ok(author);
        }
    }
}
