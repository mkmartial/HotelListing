using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8732f4-63dc-4a82-b507-2458120bc722");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58930d31-7e48-4577-b467-4ae0de30d755");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcb2fa61-aa11-4ce6-936a-d03b213243a5", "22cd09e1-2204-43f6-8816-3ab0f3c7e521", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "413989bc-06f1-4d01-be38-00b84dc144c6", "4e907499-772f-453d-8d0c-9e8bc27e9aa1", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "413989bc-06f1-4d01-be38-00b84dc144c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb2fa61-aa11-4ce6-936a-d03b213243a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58930d31-7e48-4577-b467-4ae0de30d755", "e5b508e1-c6fb-4104-bccc-b132923ce772", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b8732f4-63dc-4a82-b507-2458120bc722", "81444645-6c44-4b23-a775-62be8f8b462f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
