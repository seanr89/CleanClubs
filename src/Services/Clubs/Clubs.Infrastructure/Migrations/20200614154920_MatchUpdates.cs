using Microsoft.EntityFrameworkCore.Migrations;

namespace Clubs.Infrastructure.Migrations
{
    public partial class MatchUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Matches_Generator_Enum_Constraint",
                table: "Matches",
                sql: "[Generator] IN(0, 1, 2, 3)");

            migrationBuilder.AddColumn<int>(
                name: "Generator",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Matches_Generator_Enum_Constraint",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Generator",
                table: "Matches");
        }
    }
}
