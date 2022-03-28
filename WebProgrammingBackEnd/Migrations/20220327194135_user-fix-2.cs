using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingBackEnd.Migrations
{
    public partial class userfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Role_RolesName",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UsersId",
                table: "UserRole",
                newName: "IX_UserRole_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "RolesName", "UsersId" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 78, 120, 22, 154, 200, 127, 152, 117, 37, 213, 139, 181, 99, 212, 13, 226, 111, 46, 33, 253, 66, 2, 6, 61, 48, 236, 159, 122, 18, 37, 164, 154, 57, 240, 85, 122, 73, 49, 193, 151, 231, 61, 233, 137, 245, 196, 93, 187, 165, 145, 28, 241, 68, 78, 69, 51, 156, 30, 210, 57, 209, 138, 220, 220 }, new byte[] { 27, 43, 141, 0, 151, 216, 198, 108, 16, 107, 109, 108, 187, 165, 147, 25, 86, 142, 160, 120, 198, 223, 218, 37, 167, 91, 240, 171, 129, 13, 153, 150, 2, 199, 205, 92, 108, 24, 116, 137, 56, 150, 144, 189, 15, 147, 250, 163, 155, 40, 174, 11, 145, 44, 81, 100, 216, 61, 181, 209, 15, 213, 162, 80, 104, 55, 134, 66, 196, 132, 16, 170, 131, 114, 79, 78, 181, 11, 71, 200, 138, 215, 124, 119, 62, 198, 136, 87, 198, 79, 244, 38, 117, 120, 199, 66, 33, 83, 213, 193, 152, 59, 183, 174, 220, 52, 210, 144, 250, 168, 120, 252, 84, 217, 92, 82, 165, 232, 113, 106, 238, 190, 175, 184, 227, 82, 143, 116 } });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RolesName", "UsersId" },
                values: new object[] { "Admin", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RolesName",
                table: "UserRole",
                column: "RolesName",
                principalTable: "Role",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UsersId",
                table: "UserRole",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RolesName",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UsersId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RolesName", "UsersId" },
                keyValues: new object[] { "Admin", 1 });

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "RoleUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UsersId",
                table: "RoleUser",
                newName: "IX_RoleUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "RolesName", "UsersId" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 218, 141, 246, 197, 77, 130, 212, 176, 151, 150, 190, 224, 29, 242, 132, 88, 76, 153, 2, 251, 47, 108, 7, 126, 125, 226, 166, 106, 168, 147, 216, 149, 215, 27, 186, 106, 205, 0, 174, 48, 160, 63, 116, 57, 251, 42, 155, 221, 78, 91, 230, 54, 27, 133, 61, 166, 241, 112, 166, 142, 149, 126, 233, 102 }, new byte[] { 239, 130, 63, 164, 25, 173, 30, 36, 88, 205, 186, 154, 131, 174, 200, 211, 1, 226, 208, 2, 193, 251, 100, 17, 221, 112, 247, 211, 82, 158, 123, 36, 205, 123, 79, 137, 223, 57, 42, 71, 47, 108, 239, 203, 255, 136, 215, 173, 163, 137, 34, 22, 205, 215, 27, 135, 149, 51, 70, 86, 226, 135, 82, 184, 114, 165, 245, 2, 66, 213, 102, 155, 49, 81, 140, 169, 115, 35, 187, 183, 246, 251, 4, 207, 136, 118, 208, 240, 236, 81, 54, 7, 123, 43, 204, 88, 196, 68, 4, 40, 129, 199, 189, 39, 35, 153, 226, 90, 18, 5, 78, 154, 200, 226, 52, 182, 173, 45, 49, 14, 30, 45, 184, 5, 224, 73, 29, 90 } });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Role_RolesName",
                table: "RoleUser",
                column: "RolesName",
                principalTable: "Role",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
