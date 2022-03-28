using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingBackEnd.Migrations
{
    public partial class roleseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                column: "Name",
                value: "Admin");

            migrationBuilder.InsertData(
                table: "Role",
                column: "Name",
                value: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Name",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Name",
                keyValue: "Customer");
        }
    }
}
