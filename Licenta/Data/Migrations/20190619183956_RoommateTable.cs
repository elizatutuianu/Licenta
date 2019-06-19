using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class RoommateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dorms_AccomodationRequests_AccomodationRequestId",
                table: "Dorms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AccomodationRequests_AccomodationRequestId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationRequestId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationRequestId",
                table: "Dorms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Roommate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomodationRequestId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roommate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roommate_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roommate_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roommate_AccomodationRequestId",
                table: "Roommate",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Roommate_StudentId",
                table: "Roommate",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dorms_AccomodationRequests_AccomodationRequestId",
                table: "Dorms",
                column: "AccomodationRequestId",
                principalTable: "AccomodationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AccomodationRequests_AccomodationRequestId",
                table: "Rooms",
                column: "AccomodationRequestId",
                principalTable: "AccomodationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dorms_AccomodationRequests_AccomodationRequestId",
                table: "Dorms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AccomodationRequests_AccomodationRequestId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Roommate");

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationRequestId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationRequestId",
                table: "Dorms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dorms_AccomodationRequests_AccomodationRequestId",
                table: "Dorms",
                column: "AccomodationRequestId",
                principalTable: "AccomodationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AccomodationRequests_AccomodationRequestId",
                table: "Rooms",
                column: "AccomodationRequestId",
                principalTable: "AccomodationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
