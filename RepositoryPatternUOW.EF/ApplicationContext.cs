using Microsoft.EntityFrameworkCore;
using RepositoryPatternUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternUOW.EF
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {
            
        }

        DbSet<Author> AuthorsAuthors { get; set; }
        DbSet<Book> Books { get; set; }

    }
}
