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
        }
    }
}
