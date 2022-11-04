using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace gRPCservice.Migrations
{
    public partial class readyForHandin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    StudyProgrammeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStudentOrders",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStudentOrders", x => new { x.StudentId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookStudentOrders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "IsAvailable", "Price", "StudyProgrammeId", "Subject", "Title" },
                values: new object[,]
                {
                    { 1, "sumit", true, 200.0, 1, "How to code", "C#" },
                    { 2, "christoffer", true, 300.0, 1, "System integration", "Soa" },
                    { 3, "Alham", true, 200.0, 2, "May he be with u", "Guide to Heaven" },
                    { 4, "Praktik soon", true, 350.0, 3, "How to ace praktik", "Praktik for gods" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookStudentOrders_BookId",
                table: "BookStudentOrders",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookStudentOrders");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
