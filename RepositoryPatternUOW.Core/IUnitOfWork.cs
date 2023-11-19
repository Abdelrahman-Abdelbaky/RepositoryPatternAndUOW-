using RepositoryPatternUOW.Core.Models;
using RepositoryPatternUOW.Core.Repositors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Book> books { get; }
        IBaseRepository<Author> authors { get; }

        void Commit();

    }
}
