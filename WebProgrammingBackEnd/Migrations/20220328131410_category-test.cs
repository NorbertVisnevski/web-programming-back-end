using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingBackEnd.Migrations
{
    public partial class categorytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Category_Name",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 47, 123, 155, 158, 137, 168, 193, 124, 17, 210, 77, 117, 82, 218, 255, 74, 117, 200, 31, 57, 141, 179, 36, 83, 6, 41, 249, 56, 155, 45, 220, 154, 217, 196, 159, 250, 90, 226, 23, 187, 185, 175, 169, 238, 157, 87, 181, 250, 150, 98, 52, 158, 168, 11, 159, 171, 122, 136, 240, 245, 102, 54, 205 }, new byte[] { 166, 124, 64, 31, 142, 10, 188, 88, 226, 119, 134, 229, 150, 103, 237, 23, 129, 36, 5, 208, 120, 88, 22, 169, 30, 228, 203, 135, 41, 227, 255, 240, 105, 164, 138, 28, 222, 220, 128, 90, 36, 215, 31, 146, 0, 45, 105, 167, 0, 32, 124, 87, 71, 186, 135, 163, 178, 112, 44, 37, 85, 144, 155, 199, 143, 255, 241, 132, 200, 226, 52, 78, 18, 32, 35, 59, 62, 103, 50, 209, 51, 22, 233, 49, 11, 20, 120, 127, 155, 244, 60, 28, 97, 6, 49, 6, 77, 186, 128, 213, 189, 55, 16, 56, 158, 203, 96, 172, 175, 91, 236, 251, 59, 182, 65, 201, 113, 27, 23, 11, 250, 8, 147, 207, 96, 48, 100, 21 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Category_Name",
                table: "Category",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 78, 120, 22, 154, 200, 127, 152, 117, 37, 213, 139, 181, 99, 212, 13, 226, 111, 46, 33, 253, 66, 2, 6, 61, 48, 236, 159, 122, 18, 37, 164, 154, 57, 240, 85, 122, 73, 49, 193, 151, 231, 61, 233, 137, 245, 196, 93, 187, 165, 145, 28, 241, 68, 78, 69, 51, 156, 30, 210, 57, 209, 138, 220, 220 }, new byte[] { 27, 43, 141, 0, 151, 216, 198, 108, 16, 107, 109, 108, 187, 165, 147, 25, 86, 142, 160, 120, 198, 223, 218, 37, 167, 91, 240, 171, 129, 13, 153, 150, 2, 199, 205, 92, 108, 24, 116, 137, 56, 150, 144, 189, 15, 147, 250, 163, 155, 40, 174, 11, 145, 44, 81, 100, 216, 61, 181, 209, 15, 213, 162, 80, 104, 55, 134, 66, 196, 132, 16, 170, 131, 114, 79, 78, 181, 11, 71, 200, 138, 215, 124, 119, 62, 198, 136, 87, 198, 79, 244, 38, 117, 120, 199, 66, 33, 83, 213, 193, 152, 59, 183, 174, 220, 52, 210, 144, 250, 168, 120, 252, 84, 217, 92, 82, 165, 232, 113, 106, 238, 190, 175, 184, 227, 82, 143, 116 } });
        }
    }
}
