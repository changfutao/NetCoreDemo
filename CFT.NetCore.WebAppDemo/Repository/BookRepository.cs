using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Repository
{
    public class BookRepository : RepositoryBase<Book, Guid>,IBookRepository
    {
        public BookRepository(DbContext dbContext):base(dbContext)
        {

        }
    }
}
