using CFT.NetCore.WebAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Repository
{
    public interface IBookRepository:IRepositoryBase<Book,Guid>
    {
    }
}
