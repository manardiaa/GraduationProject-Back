using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opt1",
                table: "QuestionOptiones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opt2",
                table: "QuestionOptiones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opt3",
                table: "QuestionOptiones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opt4",
                table: "QuestionOptiones",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opt1",
                table: "QuestionOptiones");

            migrationBuilder.DropColumn(
                name: "Opt2",
                table: "QuestionOptiones");

            migrationBuilder.DropColumn(
                name: "Opt3",
                table: "QuestionOptiones");

            migrationBuilder.DropColumn(
                name: "Opt4",
                table: "QuestionOptiones");
        }
    }
}
