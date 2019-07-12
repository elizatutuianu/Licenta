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
                    LastComfortAccepted = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dorms",
                columns: table => new
                {
                    DormName = table.Column<string>(nullable: false),
                    DormComfort = table.Column<int>(nullable: false),
                    DormNoRooms = table.Column<int>(nullable: false),
                    DormGender = table.Column<string>(nullable: true),
                    IsDormForRomanians = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormBedsInRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdCardStudents",
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
                    table.PrimaryKey("PK_IdCardStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormsPreferreds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomodationRequestId = table.Column<int>(nullable: true),
                    DormId = table.Column<int>(nullable: true),
                    DormName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormsPreferreds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DormsPreferreds_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DormsPreferreds_Dorms_DormId",
                        column: x => x.DormId,
                        principalTable: "Dorms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    DormId = table.Column<int>(nullable: false),
                    IsFull = table.Column<bool>(nullable: false),
                    RoomNo = table.Column<int>(nullable: false),
                    RoomGender = table.Column<string>(nullable: true),
                    BedsInRoom = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Dorms_DormId",
                        column: x => x.DormId,
                        principalTable: "Dorms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
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
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomPreferreds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomodationRequestId = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    RoomNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPreferreds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPreferreds_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomPreferreds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
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
                    FacultyId = table.Column<int>(nullable: false),
                    SpecializationId = table.Column<int>(nullable: false),
                    IdCardStudentId = table.Column<int>(nullable: false),
                    AccomodationRequestId = table.Column<int>(nullable: true),
                    Cnp = table.Column<string>(maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Initial = table.Column<string>(nullable: true),
                    StudyProgram = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    IsSocialCase = table.Column<bool>(nullable: true),
                    IsMedicalCase = table.Column<bool>(nullable: true),
                    Media = table.Column<double>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Taxa_buget = table.Column<string>(nullable: true),
                    Group = table.Column<int>(nullable: true),
                    Credits = table.Column<int>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
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
                        name: "FK_Students_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_IdCardStudents_IdCardStudentId",
                        column: x => x.IdCardStudentId,
                        principalTable: "IdCardStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roommates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomodationRequestId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roommates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roommates_AccomodationRequests_AccomodationRequestId",
                        column: x => x.AccomodationRequestId,
                        principalTable: "AccomodationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roommates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DormsPreferreds_AccomodationRequestId",
                table: "DormsPreferreds",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DormsPreferreds_DormId",
                table: "DormsPreferreds",
                column: "DormId");

            migrationBuilder.CreateIndex(
                name: "IX_Roommates_AccomodationRequestId",
                table: "Roommates",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Roommates_StudentId",
                table: "Roommates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPreferreds_AccomodationRequestId",
                table: "RoomPreferreds",
                column: "AccomodationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPreferreds_RoomId",
                table: "RoomPreferreds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DormId",
                table: "Rooms",
                column: "DormId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_FacultyId",
                table: "Specializations",
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
                name: "IX_Students_IdCardStudentId",
                table: "Students",
                column: "IdCardStudentId");

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
                name: "DormsPreferreds");

            migrationBuilder.DropTable(
                name: "Roommates");

            migrationBuilder.DropTable(
                name: "RoomPreferreds");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AccomodationRequests");

            migrationBuilder.DropTable(
                name: "IdCardStudents");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Dorms");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
