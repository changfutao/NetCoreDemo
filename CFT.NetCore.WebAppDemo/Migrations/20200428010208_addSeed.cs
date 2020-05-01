using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFT.NetCore.WebAppDemo.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Book",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a572c7d1-6a16-48fc-a583-9d14d39e8f46"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("13361ab5-6617-4872-af0a-51528c6a290d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Author",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("df8b5114-6b3c-4684-b50d-e85bf508b7b3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("39914484-f110-4875-94ef-1afe130aec59"));

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "BirthPlace", "Email", "Name" },
                values: new object[] { new Guid("7f76013d-8b20-4fcf-9d7f-85aca9617506"), new DateTimeOffset(new DateTime(1980, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "江苏苏州", "123@126.com", "蒋金楠" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Description", "Pages", "Title" },
                values: new object[] { new Guid("d2006ca3-6bb6-4d9e-9bb0-27d950d85be5"), new Guid("7f76013d-8b20-4fcf-9d7f-85aca9617506"), "123", 500, "ASP.NET Core框架解密" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("d2006ca3-6bb6-4d9e-9bb0-27d950d85be5"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("7f76013d-8b20-4fcf-9d7f-85aca9617506"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Book",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("13361ab5-6617-4872-af0a-51528c6a290d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a572c7d1-6a16-48fc-a583-9d14d39e8f46"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Author",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("39914484-f110-4875-94ef-1afe130aec59"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("df8b5114-6b3c-4684-b50d-e85bf508b7b3"));
        }
    }
}
