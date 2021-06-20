using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrsId",
                table: "lessones",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lessones_CrsId",
                table: "lessones",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_lessones_Course_CrsId",
                table: "lessones",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessones_Course_CrsId",
                table: "lessones");

            migrationBuilder.DropIndex(
                name: "IX_lessones_CrsId",
                table: "lessones");

            migrationBuilder.DropColumn(
                name: "CrsId",
                table: "lessones");
        }
    }
}
