using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_Server.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cart",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "cart",
                newName: "Carts");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "Products",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Carts",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Carts",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");
        }
    }
}
