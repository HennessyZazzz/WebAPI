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

        public void EditBook(int id, Book book)
        {
            var findBook = _context.Book.Find(id);
            if (findBook != null)
            {
                if (book != null)
                {
                    findBook.Title = book.Title;
                    findBook.Description = book.Description;
                    findBook.IsRead = book.IsRead;
                    findBook.DateRead = book.DateRead;
                    findBook.Rate = book.Rate;
                    findBook.Genre = book.Genre;
                    findBook.Author = book.Author;
                    findBook.ImageUrl = book.ImageUrl;
                    findBook.DataAdded = book.DataAdded;

                    _context.Book.Update(findBook);
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteBook(int id)
        {
            var findBook = _context.Book.Find(id);
            if (findBook != null)
            {
                _context.Book.Remove(findBook);
                _context.SaveChanges();
            }
        }
    }
}
