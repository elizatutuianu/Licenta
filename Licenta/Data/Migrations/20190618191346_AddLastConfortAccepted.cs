using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class AddLastConfortAccepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastConfortAccepted",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastConfortAccepted",
                table: "Students");
        }
    }
}
