using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingBackEnd.Migrations
{
    public partial class userupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Category_CategoriesId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Product_ProductsId",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "CategoryProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductsId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductsId");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProduct",
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "City", "Country", "Email", "HouseNumber", "Name", "PasswordHash", "PasswordSalt", "PhoneNumber", "Street", "Surname" },
                values: new object[] { 1, null, null, "admin@admin.com", null, null, new byte[] { 218, 141, 246, 197, 77, 130, 212, 176, 151, 150, 190, 224, 29, 242, 132, 88, 76, 153, 2, 251, 47, 108, 7, 126, 125, 226, 166, 106, 168, 147, 216, 149, 215, 27, 186, 106, 205, 0, 174, 48, 160, 63, 116, 57, 251, 42, 155, 221, 78, 91, 230, 54, 27, 133, 61, 166, 241, 112, 166, 142, 149, 126, 233, 102 }, new byte[] { 239, 130, 63, 164, 25, 173, 30, 36, 88, 205, 186, 154, 131, 174, 200, 211, 1, 226, 208, 2, 193, 251, 100, 17, 221, 112, 247, 211, 82, 158, 123, 36, 205, 123, 79, 137, 223, 57, 42, 71, 47, 108, 239, 203, 255, 136, 215, 173, 163, 137, 34, 22, 205, 215, 27, 135, 149, 51, 70, 86, 226, 135, 82, 184, 114, 165, 245, 2, 66, 213, 102, 155, 49, 81, 140, 169, 115, 35, 187, 183, 246, 251, 4, 207, 136, 118, 208, 240, 236, 81, 54, 7, 123, 43, 204, 88, 196, 68, 4, 40, 129, 199, 189, 39, 35, 153, 226, 90, 18, 5, 78, 154, 200, 226, 52, 182, 173, 45, 49, 14, 30, 45, 184, 5, 224, 73, 29, 90 }, null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Category_CategoriesId",
                table: "CategoryProduct",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Product_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Category_CategoriesId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Product_ProductsId",
                table: "CategoryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProduct",
                table: "CategoryProduct");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "CategoryProduct",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductsId");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "CategoriesId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Category_CategoriesId",
                table: "ProductCategory",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Product_ProductsId",
                table: "ProductCategory",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
