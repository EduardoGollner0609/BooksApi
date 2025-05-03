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
            ResponseModel<List<AuthorModel>> authors = await _authorInterface.FindAll();
            return Ok(authors);
        }

    }
}
