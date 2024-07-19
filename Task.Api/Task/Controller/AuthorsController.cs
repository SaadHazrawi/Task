using Application.Common.Dtos.Author;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Task.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorAddDto authorAdd)
        {
        var author=  await  _authorServices.Add(authorAdd);
            return Ok(author);
        }
    }
}
