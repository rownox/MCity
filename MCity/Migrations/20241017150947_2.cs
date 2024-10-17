using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCity.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentTopicId",
                table: "LearnTopics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearnTopics_ParentTopicId",
                table: "LearnTopics",
                column: "ParentTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnTopics_LearnTopics_ParentTopicId",
                table: "LearnTopics",
                column: "ParentTopicId",
                principalTable: "LearnTopics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearnTopics_LearnTopics_ParentTopicId",
                table: "LearnTopics");

            migrationBuilder.DropIndex(
                name: "IX_LearnTopics_ParentTopicId",
                table: "LearnTopics");

            migrationBuilder.DropColumn(
                name: "ParentTopicId",
                table: "LearnTopics");
        }
    }
}
