using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class AddingNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    NoteTitle = table.Column<string>(nullable: true),
                    NoteText = table.Column<string>(nullable: true),
                    DatePosted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamNotes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamNotes");
        }
    }
}
