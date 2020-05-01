using CFT.NetCore.WebAppDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private IAuthorRepository _authorRepository = null;
        private IBookRepository _bookRepository = null;
        public RepositoryWrapper(EFContext efContext)
        {
            _efContext = efContext;
        }

        public EFContext _efContext { get; }
        public IAuthorRepository Author => _authorRepository ?? new AuthorRepository(_efContext);
        public IBookRepository Book => _bookRepository ?? new BookRepository(_efContext);
    }
}
