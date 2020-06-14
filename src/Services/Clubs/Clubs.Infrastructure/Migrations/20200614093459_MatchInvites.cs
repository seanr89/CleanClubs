using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clubs.Infrastructure.Migrations
{
    public partial class MatchInvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Matches_MatchId",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Members_MemberId",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_ClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clubs_ClubId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invite",
                table: "Invite");

            migrationBuilder.RenameTable(
                name: "Invite",
                newName: "Invites");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_MemberId",
                table: "Invites",
                newName: "IX_Invites_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_MatchId",
                table: "Invites",
                newName: "IX_Invites_MatchId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InvitesSent",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "MatchId",
                table: "Invites",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invites",
                table: "Invites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Matches_MatchId",
                table: "Invites",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Members_MemberId",
                table: "Invites",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_ClubId",
                table: "Matches",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clubs_ClubId",
                table: "Members",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Matches_MatchId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Members_MemberId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_ClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clubs_ClubId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invites",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "InvitesSent",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Invites");

            migrationBuilder.RenameTable(
                name: "Invites",
                newName: "Invite");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_MemberId",
                table: "Invite",
                newName: "IX_Invite_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_MatchId",
                table: "Invite",
                newName: "IX_Invite_MatchId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatchId",
                table: "Invite",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invite",
                table: "Invite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Matches_MatchId",
                table: "Invite",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Members_MemberId",
                table: "Invite",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_ClubId",
                table: "Matches",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clubs_ClubId",
                table: "Members",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
