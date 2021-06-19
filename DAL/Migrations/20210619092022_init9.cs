using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonContentId",
                table: "Questiones",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questiones_LessonContentId",
                table: "Questiones",
                column: "LessonContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questiones_lessonContents_LessonContentId",
                table: "Questiones",
                column: "LessonContentId",
                principalTable: "lessonContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questiones_lessonContents_LessonContentId",
                table: "Questiones");

            migrationBuilder.DropIndex(
                name: "IX_Questiones_LessonContentId",
                table: "Questiones");

            migrationBuilder.DropColumn(
                name: "LessonContentId",
                table: "Questiones");
        }
    }
}
