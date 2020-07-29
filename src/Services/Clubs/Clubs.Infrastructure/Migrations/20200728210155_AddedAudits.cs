using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clubs.Infrastructure.Migrations
{
    public partial class AddedAudits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Teams_Number_Enum_Constraint",
                table: "Teams");

            // migrationBuilder.DropCheckConstraint(
            //     name: "CK_Matches_Generator_Enum_Constraint",
            //     table: "Matches");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Matches_Status_Enum_Constraint",
                table: "Matches");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Invites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Invites",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Invites",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Invites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Invites");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Teams_Number_Enum_Constraint",
                table: "Teams",
                sql: "[Number] IN(0, 1)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Matches_Generator_Enum_Constraint",
                table: "Matches",
                sql: "[Generator] IN(0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Matches_Status_Enum_Constraint",
                table: "Matches",
                sql: "[Status] IN(0, 1, 2, 3, 4)");
        }
    }
}
