using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Lable",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxMark",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAnswerId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCorrect",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_UserAnswerId",
                table: "Options",
                column: "UserAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_UsersId",
                table: "TestUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_UserAnswers_UserAnswerId",
                table: "Options",
                column: "UserAnswerId",
                principalTable: "UserAnswers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Users_UserId",
                table: "UserAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_UserAnswers_UserAnswerId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Users_UserId",
                table: "UserAnswers");

            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Options_UserAnswerId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "Lable",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MaxMark",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UserAnswerId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "isCorrect",
                table: "Options");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
