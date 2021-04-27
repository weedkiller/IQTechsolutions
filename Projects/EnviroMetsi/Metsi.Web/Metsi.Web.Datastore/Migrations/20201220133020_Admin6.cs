using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "UserInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_StudentId",
                table: "UserInfo",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Student_StudentId",
                table: "UserInfo",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Student_StudentId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_StudentId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Student");
        }
    }
}
