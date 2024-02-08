using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Users_UserId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_UserId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "isComplited",
                table: "TestUsers",
                newName: "IsComplited");

            migrationBuilder.AddColumn<Guid>(
                name: "TestTaskId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TestTaskId",
                table: "UserAnswers",
                column: "TestTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Tasks_TestTaskId",
                table: "UserAnswers",
                column: "TestTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Tasks_TestTaskId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_TestTaskId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "TestTaskId",
                table: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "IsComplited",
                table: "TestUsers",
                newName: "isComplited");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_UserId",
                table: "Options",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Users_UserId",
                table: "Options",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
