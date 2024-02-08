using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealtionTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Tasks_TaskId",
                table: "UserAnswers");

            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_TaskId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "UserAnswers",
                newName: "OptionId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_OptionId",
                table: "UserAnswers",
                column: "OptionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Users_UserId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_OptionId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Options_UserId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "UserAnswers",
                newName: "TestId");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    TestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.TestsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TaskId",
                table: "UserAnswers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_UsersId",
                table: "TestUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Tasks_TaskId",
                table: "UserAnswers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
