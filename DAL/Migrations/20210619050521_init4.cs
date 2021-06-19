using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "crsID",
                table: "lessonContents",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lessonContents_crsID",
                table: "lessonContents",
                column: "crsID");

            migrationBuilder.AddForeignKey(
                name: "FK_lessonContents_Course_crsID",
                table: "lessonContents",
                column: "crsID",
                principalTable: "Course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessonContents_Course_crsID",
                table: "lessonContents");

            migrationBuilder.DropIndex(
                name: "IX_lessonContents_crsID",
                table: "lessonContents");

            migrationBuilder.DropColumn(
                name: "crsID",
                table: "lessonContents");
        }
    }
}
