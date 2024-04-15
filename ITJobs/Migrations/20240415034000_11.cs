using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITJobs.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Companies_CompaniesId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Users_UsersId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Conversations");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Conversations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "Conversations",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_UsersId",
                table: "Conversations",
                newName: "IX_Conversations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_CompaniesId",
                table: "Conversations",
                newName: "IX_Conversations_CompanyId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Companies_CompanyId",
                table: "Conversations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Users_UserId",
                table: "Conversations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Companies_CompanyId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Users_UserId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Conversations",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Conversations",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations",
                newName: "IX_Conversations_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_CompanyId",
                table: "Conversations",
                newName: "IX_Conversations_CompaniesId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SenderId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Conversations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Companies_CompaniesId",
                table: "Conversations",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Users_UsersId",
                table: "Conversations",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
