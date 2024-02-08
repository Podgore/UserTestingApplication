using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_UserAnswers_UserAnswerId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_UserAnswerId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "UserAnswerId",
                table: "Options");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TestId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TestId",
                table: "TestUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TestUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TaskId",
                table: "UserAnswers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TestUsers_TestId",
                table: "TestUsers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestUsers_UserId",
                table: "TestUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestUsers_Tests_TestId",
                table: "TestUsers",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestUsers_Users_UserId",
                table: "TestUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Tasks_TaskId",
                table: "UserAnswers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestUsers_Tests_TestId",
                table: "TestUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestUsers_Users_UserId",
                table: "TestUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Tasks_TaskId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_TaskId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestUsers_TestId",
                table: "TestUsers");

            migrationBuilder.DropIndex(
                name: "IX_TestUsers_UserId",
                table: "TestUsers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "TestUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TestUsers");

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserAnswerId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_UserAnswerId",
                table: "Options",
                column: "UserAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_UserAnswers_UserAnswerId",
                table: "Options",
                column: "UserAnswerId",
                principalTable: "UserAnswers",
                principalColumn: "Id");
        }
    }
}
