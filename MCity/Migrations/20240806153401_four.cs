using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCity.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics");

            migrationBuilder.AlterColumn<int>(
                name: "HomePageId",
                table: "LearnTopics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics",
                column: "HomePageId",
                unique: true,
                filter: "[HomePageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics");

            migrationBuilder.AlterColumn<int>(
                name: "HomePageId",
                table: "LearnTopics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics",
                column: "HomePageId",
                unique: true);
        }
    }
}
