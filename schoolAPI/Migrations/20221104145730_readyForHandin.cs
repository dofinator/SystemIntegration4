using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolAPI.Migrations
{
    public partial class readyForHandin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgrammes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStudyProgrammes",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    StudyProgrammeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudyProgrammes", x => new { x.StudentId, x.StudyProgrammeId });
                    table.ForeignKey(
                        name: "FK_StudentStudyProgrammes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudyProgrammes_StudyProgrammes_StudyProgrammeId",
                        column: x => x.StudyProgrammeId,
                        principalTable: "StudyProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Sumit@gmail.com", "Sumit" },
                    { 2, "Christoffer@gmail.com", "Christoffer" }
                });

            migrationBuilder.InsertData(
                table: "StudyProgrammes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SI" },
                    { 2, "DLS" },
                    { 3, "Test" }
                });

            migrationBuilder.InsertData(
                table: "StudentStudyProgrammes",
                columns: new[] { "StudentId", "StudyProgrammeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudyProgrammes_StudyProgrammeId",
                table: "StudentStudyProgrammes",
                column: "StudyProgrammeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudyProgrammes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyProgrammes");
        }
    }
}
