using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCorrect",
                table: "Options",
                newName: "IsComplited");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplited",
                table: "Options",
                newName: "isCorrect");
        }
    }
}
