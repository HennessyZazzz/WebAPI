using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.ViewModels;

namespace WebAPI.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthor()
        {
            var allAuthor = _context.Author.ToList();
            return allAuthor;
        }

        public Author AddAuthor(AuthorVM author)
        {
            var newAuthor = new Author()
            {
               FullName = author.FullName
            };

            _context.Author.Add(newAuthor);
            _context.SaveChanges();

            return newAuthor;
        }

        public Author UpdateAuthorById(int authorId, Author author)
        {
            var _author = _context.Author.FirstOrDefault(n => n.Id == authorId);

            if (_author != null)
            {
                _author.FullName = author.FullName;
                _author.Book_Author = author.Book_Author;
                _context.SaveChanges();
            }

            return _author;
        }

        public void DeleteAuthor(int authorId)
        {
            var _author = _context.Author.FirstOrDefault(n => n.Id == authorId);

            if (_author != null)
            {
                _context.Author.Remove(_author);
                _context.SaveChanges();
            }
        }
    }
}
