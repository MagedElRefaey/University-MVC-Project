using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CoursesCourseID",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CoursesCourseID",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CoursesCourseID",
                table: "StudentCourses");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "StudentCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "StudentCourses");

            migrationBuilder.AddColumn<int>(
                name: "CoursesCourseID",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CoursesCourseID",
                table: "StudentCourses",
                column: "CoursesCourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CoursesCourseID",
                table: "StudentCourses",
                column: "CoursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
