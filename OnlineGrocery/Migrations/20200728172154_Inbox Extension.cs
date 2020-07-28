using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class InboxExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MessagesInbox",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MessagesInbox",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "MessagesInbox");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MessagesInbox");
        }
    }
}
