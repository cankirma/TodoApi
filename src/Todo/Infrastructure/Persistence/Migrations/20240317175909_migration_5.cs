using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Content", "CreateTime", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a91e99d-fa6c-43ee-98f3-6534ffd24ecf"), "This is the second todo", new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5402), "Second Todo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1e1b5dc-fc19-4d81-b556-1946eb707861"), "This is the first todo", new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5401), "First Todo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateTime", "Email", "FirstName", "LastName", "Password", "UpdatedDate" },
                values: new object[] { new Guid("4ff9a10a-a601-4a6b-82c2-c5a30982c142"), new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5537), "user@example.com", "Can", "Candan", "D0B3749570B6AA9155E3CAF5E42D9AEFE826600AF86A80EE4051CE6F76FA5D0D:2A59480760E144B6C0BC4954D3C2B37B:50000:SHA256", new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5538) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("0a91e99d-fa6c-43ee-98f3-6534ffd24ecf"));

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("d1e1b5dc-fc19-4d81-b556-1946eb707861"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ff9a10a-a601-4a6b-82c2-c5a30982c142"));
        }
    }
}
