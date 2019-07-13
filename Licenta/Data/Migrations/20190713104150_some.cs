﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta.Migrations
{
    public partial class some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
