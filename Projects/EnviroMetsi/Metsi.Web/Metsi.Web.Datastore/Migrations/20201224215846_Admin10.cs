using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Employee_StudentId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_EmployeeId",
                table: "UserInfo",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Employee_EmployeeId",
                table: "UserInfo",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Employee_EmployeeId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_EmployeeId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Employee_StudentId",
                table: "UserInfo",
                column: "StudentId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
