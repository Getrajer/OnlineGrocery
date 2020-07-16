using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGrocery.Migrations
{
    public partial class AddCMSIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndexPageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header_H1 = table.Column<string>(nullable: true),
                    Header_P1_Welcome = table.Column<string>(nullable: true),
                    About_1_H3 = table.Column<string>(nullable: true),
                    About_1_Img_Path = table.Column<string>(nullable: true),
                    About_1_Text = table.Column<string>(nullable: true),
                    About_2_H3 = table.Column<string>(nullable: true),
                    About_2_Img_Path = table.Column<string>(nullable: true),
                    About_2_Text = table.Column<string>(nullable: true),
                    About_3_H3 = table.Column<string>(nullable: true),
                    About_3_Img_Path = table.Column<string>(nullable: true),
                    About_3_Text = table.Column<string>(nullable: true),
                    Contact_H3 = table.Column<string>(nullable: true),
                    Contact_P = table.Column<string>(nullable: true),
                    Contact_Phone_1 = table.Column<string>(nullable: true),
                    Contact_Phone_2 = table.Column<string>(nullable: true),
                    Contact_Email_1 = table.Column<string>(nullable: true),
                    Contact_Email_2 = table.Column<string>(nullable: true),
                    Contact_Address_Street = table.Column<string>(nullable: true),
                    Contact_Address_Postcode = table.Column<string>(nullable: true),
                    Contact_Address_City = table.Column<string>(nullable: true),
                    ContactFormToggler = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexPageModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexPageModel");
        }
    }
}
