using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGroupes_lessonContents_LessonContentId",
                table: "QuestionGroupes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionGroupes_LessonContentId",
                table: "QuestionGroupes");

            migrationBuilder.DropColumn(
                name: "LessonContentId",
                table: "QuestionGroupes");

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "CourseVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfLesson = table.Column<int>(type: "int", nullable: false),
                    NumOfLessonFinshed = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Progress_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progress_CourseId",
                table: "Progress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentId",
                table: "Progress",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "CourseVideos");

            migrationBuilder.AddColumn<int>(
                name: "LessonContentId",
                table: "QuestionGroupes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGroupes_LessonContentId",
                table: "QuestionGroupes",
                column: "LessonContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGroupes_lessonContents_LessonContentId",
                table: "QuestionGroupes",
                column: "LessonContentId",
                principalTable: "lessonContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
