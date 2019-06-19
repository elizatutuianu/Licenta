using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class FKRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dorms_DormId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "DormId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dorms_DormId",
                table: "Rooms",
                column: "DormId",
                principalTable: "Dorms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dorms_DormId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "DormId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dorms_DormId",
                table: "Rooms",
                column: "DormId",
                principalTable: "Dorms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
