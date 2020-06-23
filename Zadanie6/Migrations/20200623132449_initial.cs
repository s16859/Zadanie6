using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie6.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studies",
                columns: table => new
                {
                    IdStudy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studies", x => x.IdStudy);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    IdEnrollment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    IdStudy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.IdEnrollment);
                    table.ForeignKey(
                        name: "FK_enrollments_studies_IdStudy",
                        column: x => x.IdStudy,
                        principalTable: "studies",
                        principalColumn: "IdStudy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    IndexNumber = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IdEnrollment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.IndexNumber);
                    table.ForeignKey(
                        name: "FK_students_enrollments_IdEnrollment",
                        column: x => x.IdEnrollment,
                        principalTable: "enrollments",
                        principalColumn: "IdEnrollment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "studies",
                columns: new[] { "IdStudy", "Name" },
                values: new object[] { 1, "Jakies" });

            migrationBuilder.InsertData(
                table: "enrollments",
                columns: new[] { "IdEnrollment", "IdStudy", "Semester", "StartDate" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 6, 23, 15, 24, 49, 327, DateTimeKind.Local).AddTicks(5687) });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "IndexNumber", "BirthDate", "FirstName", "IdEnrollment", "LastName" },
                values: new object[] { "s16859", new DateTime(1995, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przemyslaw", 1, "Szczerba" });

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_IdStudy",
                table: "enrollments",
                column: "IdStudy");

            migrationBuilder.CreateIndex(
                name: "IX_students_IdEnrollment",
                table: "students",
                column: "IdEnrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "studies");
        }
    }
}
