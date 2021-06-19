using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class whatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "watched",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    whatchedOrNot = table.Column<int>(type: "int", nullable: false),
                    lessonContentID = table.Column<int>(type: "int", nullable: false),
                    stID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CrsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watched", x => x.id);
                    table.ForeignKey(
                        name: "FK_watched_AspNetUsers_stID",
                        column: x => x.stID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_watched_Course_CrsID",
                        column: x => x.CrsID,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_watched_lessonContents_lessonContentID",
                        column: x => x.lessonContentID,
                        principalTable: "lessonContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_watched_CrsID",
                table: "watched",
                column: "CrsID");

            migrationBuilder.CreateIndex(
                name: "IX_watched_lessonContentID",
                table: "watched",
                column: "lessonContentID");

            migrationBuilder.CreateIndex(
                name: "IX_watched_stID",
                table: "watched",
                column: "stID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "watched");
        }
    }
}
