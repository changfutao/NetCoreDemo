﻿// <auto-generated />
using System;
using CFT.NetCore.WebAppDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CFT.NetCore.WebAppDemo.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20200428010208_addSeed")]
    partial class addSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CFT.NetCore.WebAppDemo.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("df8b5114-6b3c-4684-b50d-e85bf508b7b3"));

                    b.Property<DateTimeOffset>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTimeOffset")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasDefaultValue("");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValue("");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7f76013d-8b20-4fcf-9d7f-85aca9617506"),
                            BirthDate = new DateTimeOffset(new DateTime(1980, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "江苏苏州",
                            Email = "123@126.com",
                            Name = "蒋金楠"
                        });
                });

            modelBuilder.Entity("CFT.NetCore.WebAppDemo.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("a572c7d1-6a16-48fc-a583-9d14d39e8f46"));

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(500)")
                        .HasDefaultValue("");

                    b.Property<int>("Pages")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(100)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2006ca3-6bb6-4d9e-9bb0-27d950d85be5"),
                            AuthorId = new Guid("7f76013d-8b20-4fcf-9d7f-85aca9617506"),
                            Description = "123",
                            Pages = 500,
                            Title = "ASP.NET Core框架解密"
                        });
                });

            modelBuilder.Entity("CFT.NetCore.WebAppDemo.Models.Book", b =>
                {
                    b.HasOne("CFT.NetCore.WebAppDemo.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
