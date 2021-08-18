using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if(!context.Book.Any())
                {
                    context.Book.AddRange(
                        new Models.Book()
                        {
                            Title = "Beginning C++20",
                            Description = "From Novice to Professional",
                            Author = "Horton, Ivor, Van Weert, Peter",
                            IsRead = true,
                            Rate = 4,
                            DateRead = DateTime.Now.AddDays(-24),
                            Genre = "Programing",
                            ImageUrl = "https://media.springernature.com/w153/springer-static/cover/book/9781484258842.jpg",
                            DataAdded = DateTime.Now.AddDays(-48)
                        },

                        new Models.Book()
                        {
                            Title = "Beginning T-SQL",
                            Description = "A Step-by-Step Approach",
                            Author = "Kellenberger, Kathi, Everest, Lee",
                            IsRead = false,
                            Genre = "Programing",
                            ImageUrl = "https://media.springernature.com/w153/springer-static/cover/book/9781484266069.jpg",
                            DataAdded = DateTime.Now.AddDays(-48)
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
