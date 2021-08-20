using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.ViewModels;
using WebAPI.Services;

namespace WebAPI.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("get-all-author")]
        public IActionResult GetAllAuthor()
        {
            var allAuthor = _authorService.GetAllAuthor();
            return Ok(allAuthor);
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            var newAuthor = _authorService.AddAuthor(author);
            return Created(nameof(AddAuthor), newAuthor);
        }

        [HttpPut("update-author/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody] Author author)
        {
            var updatedAuthor = _authorService.UpdateAuthorById(id, author);
            return Ok(updatedAuthor);
        }

        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
