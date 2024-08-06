using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCity.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnTopics_LearnPages_HomePageId",
                table: "LearnTopics");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages",
                column: "LearnTopicId",
                principalTable: "LearnTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LearnTopics_LearnPages_HomePageId",
                table: "LearnTopics",
                column: "HomePageId",
                principalTable: "LearnPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
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
    }
}
