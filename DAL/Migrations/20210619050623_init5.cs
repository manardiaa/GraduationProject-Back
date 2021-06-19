using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LectureID",
                table: "lessonContents",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lessonContents_LectureID",
                table: "lessonContents",
                column: "LectureID");

            migrationBuilder.AddForeignKey(
                name: "FK_lessonContents_lecture_LectureID",
                table: "lessonContents",
                column: "LectureID",
                principalTable: "lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessonContents_lecture_LectureID",
                table: "lessonContents");

            migrationBuilder.DropIndex(
                name: "IX_lessonContents_LectureID",
                table: "lessonContents");

            migrationBuilder.DropColumn(
                name: "LectureID",
                table: "lessonContents");
        }
    }
}
