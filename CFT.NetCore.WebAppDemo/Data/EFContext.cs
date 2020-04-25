using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Data
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions options):base(options)
        {
        }
    }
}
