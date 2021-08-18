using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;

        public BooksController(BookService booksSerice)
        {
            _bookService = booksSerice;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] Book book)
        {
            var updatedBook = _bookService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
