using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFT.NetCore.WebAppDemo.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("39914484-f110-4875-94ef-1afe130aec59")),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: ""),
                    BirthDate = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false, defaultValueSql: "GETDATE()"),
                    BirthPlace = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("13361ab5-6617-4872-af0a-51528c6a290d")),
                    Title = table.Column<string>(type: "NVARCHAR(100)", nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false, defaultValue: ""),
                    Pages = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
