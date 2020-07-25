using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class AddingStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatestRegisterName = table.Column<string>(nullable: true),
                    LatestRegisterDate = table.Column<DateTime>(nullable: false),
                    UsersMeanMoneySpent = table.Column<double>(nullable: false),
                    AmmountOfUsers = table.Column<int>(nullable: false),
                    TotalSalesMoney = table.Column<double>(nullable: false),
                    OrderMoneyMean = table.Column<double>(nullable: false),
                    TotalNumberOfOrders = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
