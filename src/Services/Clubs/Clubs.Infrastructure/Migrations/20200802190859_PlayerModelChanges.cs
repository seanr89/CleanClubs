using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clubs.Infrastructure.Migrations
{
    public partial class PlayerModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Players");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Players");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
