using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class OrderFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "UserOrdersItems");

            migrationBuilder.DropColumn(
                name: "ItemOrderId",
                table: "UserOrdersItems");

            migrationBuilder.DropColumn(
                name: "OrderedItemsId",
                table: "UserOrders");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "UserOrdersItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "UserOrdersItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderId",
                table: "UserOrdersItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "UserOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UserOrdersItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "UserOrdersItems");

            migrationBuilder.DropColumn(
                name: "ProductOrderId",
                table: "UserOrdersItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UserOrders");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "UserOrdersItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemOrderId",
                table: "UserOrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderedItemsId",
                table: "UserOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
