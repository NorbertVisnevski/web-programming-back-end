using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingBackEnd.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "CategoryProduct",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductsId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Category_CategoriesId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Product_ProductsId",
                table: "ProductCategory");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Category_Name",
                table: "Category");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProduct",
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" });

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
    }
}
