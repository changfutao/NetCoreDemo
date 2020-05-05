using CFT.NetCore.WebAppDemo.Mappings;
using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Data
{
    public class EFContext:DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
     = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public EFContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent API
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            //初始化数据
            modelBuilder.SeedData();

        }
    }
}
