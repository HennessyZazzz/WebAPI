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

        [HttpPost("create-book")]
        public IActionResult CreateBook(Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditBook(int id, Book book)
        {
            _bookService.EditBook(id, book);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeketeBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
