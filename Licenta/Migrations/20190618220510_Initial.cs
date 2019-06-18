using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccomodationRequests",
                columns: table => new
                {
                    ArConfort = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdCardStudent",
                columns: table => new
                {
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    IdCardNo = table.Column<string>(nullable: true),
                    IdCardIssuedBy = table.Column<string>(nullable: true),
                    IdCardIssuedDate = table.Column<DateTime>(nullable: false),
                    District = table.Column<string>(nullable: true),
                    Localty = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CivilStatus = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCardStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dorms",
                columns: table => new
                {
                    DormName = table.Column<string>(nullable: false),
                    DormComfort = table.Column<int>(nullable: false),
                    DormNoRooms = table.Column<int>(nullable: false),
                    DormBedsInRoom = table.Column<int>(nullable: false),
                    DormGender = table.Column<string>(nullable: false),
                    IsDormForRomanians = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormBedsInRoom1 = table.Column<int>(nullable: false),
                    RoomGender = table.Column<string>(nullable: true),
                    AccomodationRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dorms_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SpecName = table.Column<string>(nullable: true),
                    SpecNoOfStudents = table.Column<int>(nullable: false),
                    SpecNoOfFemaleStudents = table.Column<int>(nullable: false),
                    SpecLanguageOfStudy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialization_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNo = table.Column<int>(nullable: false),
                    RoomGender = table.Column<string>(nullable: true),
                    BedsInRoom = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomodationRequestId = table.Column<int>(nullable: true),
                    DormId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Dorms_DormId",
                        column: x => x.DormId,
                        principalTable: "Dorms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cnp = table.Column<string>(maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Initial = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true),
                    SpecializationId = table.Column<int>(nullable: true),
                    StudyProgram = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    IsSocialCase = table.Column<bool>(nullable: false),
                    IsMedicalCase = table.Column<bool>(nullable: false),
                    Media = table.Column<float>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Taxa_buget = table.Column<string>(nullable: true),
                    Group = table.Column<int>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true),
                    AccomodationRequestId = table.Column<int>(nullable: true),
                    IdCardStudent1Id = table.Column<int>(nullable: true),
                    LastConfortAccepted = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_IdCardStudent_IdCardStudent1Id",
                        column: x => x.IdCardStudent1Id,
                        principalTable: "IdCardStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dorms_AccomodationRequestId",
                table: "Dorms",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AccomodationRequestId",
                table: "Rooms",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DormId",
                table: "Rooms",
                column: "DormId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_FacultyId",
                table: "Specialization",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AccomodationRequestId",
                table: "Students",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdCardStudent1Id",
                table: "Students",
                column: "IdCardStudent1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                table: "Students",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SpecializationId",
                table: "Students",
                column: "SpecializationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "IdCardStudent");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Dorms");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "AccomodationRequests");
        }
    }
}
