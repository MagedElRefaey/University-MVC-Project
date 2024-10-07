using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentsDepartmentID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CoursesDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentsDepartmentID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentsDepartmentID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentDescription",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesCourseID = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesCourseID, x.DepartmentsDepartmentId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_CoursesCourseID",
                        column: x => x.CoursesCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_DepartmentsDepartmentId",
                        column: x => x.DepartmentsDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentNo",
                table: "Students",
                column: "DepartmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDepartmentId",
                table: "CourseDepartment",
                column: "DepartmentsDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentNo",
                table: "Students",
                column: "DepartmentNo",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentNo",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentNo",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "DepartmentID");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsDepartmentID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentDescription",
                table: "Departments",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "CoursesDepartment",
                columns: table => new
                {
                    CoursesCourseID = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDepartment", x => new { x.CoursesCourseID, x.DepartmentsDepartmentID });
                    table.ForeignKey(
                        name: "FK_CoursesDepartment_Courses_CoursesCourseID",
                        column: x => x.CoursesCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesDepartment_Departments_DepartmentsDepartmentID",
                        column: x => x.DepartmentsDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentsDepartmentID",
                table: "Students",
                column: "DepartmentsDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesDepartment_DepartmentsDepartmentID",
                table: "CoursesDepartment",
                column: "DepartmentsDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentsDepartmentID",
                table: "Students",
                column: "DepartmentsDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
