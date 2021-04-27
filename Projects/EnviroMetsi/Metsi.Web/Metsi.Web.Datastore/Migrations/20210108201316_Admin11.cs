using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "StudentCourseCourseId",
                table: "Module",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCourseStudentId",
                table: "Module",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Module_StudentCourseStudentId_StudentCourseCourseId",
                table: "Module",
                columns: new[] { "StudentCourseStudentId", "StudentCourseCourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Module_StudentCourse_StudentCourseStudentId_StudentCourseCourseId",
                table: "Module",
                columns: new[] { "StudentCourseStudentId", "StudentCourseCourseId" },
                principalTable: "StudentCourse",
                principalColumns: new[] { "StudentId", "CourseId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_StudentCourse_StudentCourseStudentId_StudentCourseCourseId",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "IX_Module_StudentCourseStudentId_StudentCourseCourseId",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "StudentCourseCourseId",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "StudentCourseStudentId",
                table: "Module");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
