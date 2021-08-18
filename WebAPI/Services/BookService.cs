using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks() => _context.Book.ToList();

        public void AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public Book UpdateBookById(int bookId, Book book)
        {
            var _book = _context.Book.FirstOrDefault(n => n.Id == bookId);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Author = book.Author;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.ImageUrl = book.ImageUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBook(int bookId)
        {
            var _book = _context.Book.FirstOrDefault(n => n.Id == bookId);

            if (_book != null)
            {
                _context.Book.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
