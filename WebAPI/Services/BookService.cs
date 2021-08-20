using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.ViewModels;

namespace WebAPI.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                DataAdded = book.DataAdded,
                PublisherId = book.PublisherId
            };
            _context.Book.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorId)
            {
                var _book_author = new Book_Author
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Author.Add(_book_author);
                _context.SaveChanges();
            }
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
