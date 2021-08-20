using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.ViewModels;

namespace WebAPI.Services
{
    public class PublishersService
    {
        private readonly ApplicationDbContext _context;

        public PublishersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publishers AddPublisher(PublishersVM publishersVM)
        {
            var _publisher = new Publishers()
            {
                Name = publishersVM.Name
            };

            _context.Publisher.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public List<Publishers> GetAllPublishers()
        {
            var allPublishers = _context.Publisher.ToList();
            return allPublishers; 
        }

        public Publishers UpdatePublishersById(int publisherId, Publishers publishers)
        {
            var _publisher = _context.Publisher.FirstOrDefault(n => n.Id == publisherId);

            if (_publisher != null)
            {
                _publisher.Name = publishers.Name;
                _publisher.Books = publishers.Books;
                _context.SaveChanges();
            }

            return _publisher;
        }

        public void DeletePublishers(int publisherId)
        {
            var _publisher = _context.Publisher.FirstOrDefault(n => n.Id == publisherId);

            if (_publisher != null)
            {
                _context.Publisher.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
