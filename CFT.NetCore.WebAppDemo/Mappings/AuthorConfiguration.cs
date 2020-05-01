using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Mappings
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //设置表名
            builder.ToTable("Author");
            //主键
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Name).HasColumnType("NVARCHAR(50)").HasDefaultValue("").IsRequired();
            builder.Property(x => x.BirthPlace).HasColumnType("NVARCHAR(50)").HasDefaultValue("").IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("DateTimeOffset").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(50)").HasDefaultValue("").IsRequired();
            //一对多
            builder.HasMany(x => x.Books)
                   .WithOne(x=>x.Author)
                   .HasForeignKey(x =>x.AuthorId);

            //builder.HasData(new List<Author> 
            //{
            //    new Author{ Id=Guid.NewGuid(),Name="蒋金楠", BirthDate=new DateTimeOffset(new DateTime(1980,3,10)), BirthPlace="江苏苏州", Email="123@126.com", 
            //      Books=new List<Book>
            //     {
            //        new Book{ Id=Guid.NewGuid(), }
            //     } 
            //    },
            //    new Author{ Id=Guid.NewGuid(),Name="杨万青", BirthDate=new DateTimeOffset(new DateTime(1989,3,10)), BirthPlace="北京", Email="123123@126.com"}
            //});
        }
    }
}
