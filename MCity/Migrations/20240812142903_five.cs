using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCity.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_LearnTopics_HomePageId",
                table: "LearnTopics");

            migrationBuilder.DropColumn(
                name: "HomePageId",
                table: "LearnTopics");

            migrationBuilder.AlterColumn<int>(
                name: "LearnTopicId",
                table: "LearnPages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages",
                column: "LearnTopicId",
                principalTable: "LearnTopics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearnPages_LearnTopics_LearnTopicId",
                table: "LearnPages");

            migrationBuilder.AddColumn<int>(
                name: "HomePageId",
                table: "LearnTopics",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LearnTopicId",
                table: "LearnPages",
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
    }
}
