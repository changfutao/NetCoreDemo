using CFT.NetCore.WebAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Mappings
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Title).HasColumnType("NVARCHAR(100)").HasDefaultValue("").IsRequired();
            builder.Property(x => x.Description).HasColumnType("NVARCHAR(500)").HasDefaultValue("").IsRequired();
            builder.Property(x => x.Pages).HasColumnType("INT").HasDefaultValue(0).IsRequired();
            builder.Property(x => x.AuthorId).HasColumnType("uniqueidentifier").IsRequired();
        }
    }
}
