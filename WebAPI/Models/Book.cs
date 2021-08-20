using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DataAdded { get; set; }

        public int PublisherId { get; set; }
        public Publishers Publishers { get; set; }

        public List<Book_Author> Book_Author { get; set; }
    }
}
