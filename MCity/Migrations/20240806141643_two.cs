using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCity.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pages",
                table: "LearnTopics");

            migrationBuilder.RenameColumn(
                name: "HomePage",
                table: "LearnTopics",
                newName: "HomePageId");

            migrationBuilder.AddColumn<int>(
                name: "LearnTopicId",
                table: "LearnPages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics",
                column: "HomePageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearnPages_LearnTopicId",
                table: "LearnPages",
                column: "LearnTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages",
                column: "LearnTopicId",
                principalTable: "LearnTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LearnTopics_LearnPages_HomePageId",
                table: "LearnTopics",
                column: "HomePageId",
                principalTable: "LearnPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnTopics_LearnPages_HomePageId",
                table: "LearnTopics");

            migrationBuilder.DropIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics");

            migrationBuilder.DropIndex(
                name: "IX_LearnPages_LearnTopicId",
                table: "LearnPages");

            migrationBuilder.DropColumn(
                name: "LearnTopicId",
                table: "LearnPages");

            migrationBuilder.RenameColumn(
                name: "HomePageId",
                table: "LearnTopics",
                newName: "HomePage");

            migrationBuilder.AddColumn<string>(
                name: "Pages",
                table: "LearnTopics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
