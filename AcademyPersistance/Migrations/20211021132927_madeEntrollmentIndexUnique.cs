using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyEfPersistance.Migrations
{
    public partial class madeEntrollmentIndexUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments",
                columns: new[] { "StudentId", "CourseEditionId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_CourseEditionId",
                table: "Enrollments",
                columns: new[] { "StudentId", "CourseEditionId" });
        }
    }
}
