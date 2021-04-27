using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employee",
                newName: "UserInfoId");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Employee_StudentId",
                table: "UserInfo",
                column: "StudentId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Employee_StudentId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Employee",
                newName: "UserId");
        }
    }
}
