using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class DropDormFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DormBedsInRoom1",
                table: "Dorms");

            migrationBuilder.DropColumn(
                name: "RoomGender",
                table: "Dorms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DormBedsInRoom1",
                table: "Dorms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomGender",
                table: "Dorms",
                nullable: true);
        }
    }
}
