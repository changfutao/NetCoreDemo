using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Repository
{
    public class AuthorRepository:RepositoryBase<Author,Guid>,IAuthorRepository
    {
        public AuthorRepository(DbContext dbContext):base(dbContext)
        {

        }
    }
}
