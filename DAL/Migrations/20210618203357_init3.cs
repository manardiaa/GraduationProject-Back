using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lessonContentId",
                table: "StudentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_lessonContentId",
                table: "StudentAnswers",
                column: "lessonContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_lessonContents_lessonContentId",
                table: "StudentAnswers",
                column: "lessonContentId",
                principalTable: "lessonContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_lessonContents_lessonContentId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_lessonContentId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "lessonContentId",
                table: "StudentAnswers");
        }
    }
}
