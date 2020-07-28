using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class FixDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "TeamNotes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DatePosted",
                table: "TeamNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
