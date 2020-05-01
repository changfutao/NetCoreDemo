using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            Guid newId = Guid.NewGuid();
            modelBuilder.Entity<Author>().HasData(new List<Author>
            {
                new Author{ Id=newId,Name="蒋金楠", BirthDate=new DateTimeOffset(new DateTime(1980,3,10)), BirthPlace="江苏苏州", Email="123@126.com"
                
                }
            });

            modelBuilder.Entity<Book>().HasData(new List<Book>
            {
               new Book{ Id=Guid.NewGuid(), Title="ASP.NET Core框架解密", Description="123", Pages=500, AuthorId=newId }
            });
        }
    }
}
