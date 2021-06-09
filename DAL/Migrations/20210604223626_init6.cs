using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LectureDescription",
                table: "lecture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrsLogo",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartLogo",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreRequest",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatImage",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureDescription",
                table: "lecture");

            migrationBuilder.DropColumn(
                name: "CrsLogo",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "PartLogo",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "PreRequest",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CatDescription",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CatImage",
                table: "Category");
        }
    }
}
