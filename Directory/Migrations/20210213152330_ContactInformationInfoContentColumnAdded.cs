using Microsoft.EntityFrameworkCore.Migrations;

namespace Directory.Migrations
{
    public partial class ContactInformationInfoContentColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InformationContent",
                table: "ContactInformation",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationContent",
                table: "ContactInformation");
        }
    }
}
