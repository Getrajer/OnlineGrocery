using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class MessagesSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessagesInbox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Sent = table.Column<DateTime>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Resolved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesInbox", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesInbox");
        }
    }
}
