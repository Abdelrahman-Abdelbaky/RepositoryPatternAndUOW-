using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternUOW.Core.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId  { get; set; }
        public Author Author { get; set; }
    }
}
