using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternUOW.Core;
using RepositoryPatternUOW.Core.Models;
using RepositoryPatternUOW.Core.Repositors;
using RepositoryPatternUOW.EF.Repository;

namespace RepositoryPatternUOW.EF
{
    public class UnitOfWork : IUnitOfWork

    {
        public IBaseRepository<Book> books { get ; }

        public IBaseRepository<Author> authors { get; }

        public readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            books = new RepositoryItem<Book>(_context);
            authors = new RepositoryItem<Author>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
