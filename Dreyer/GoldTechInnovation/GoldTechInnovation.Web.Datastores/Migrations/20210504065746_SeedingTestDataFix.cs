using Microsoft.EntityFrameworkCore.Migrations;

namespace GoldTechInnovation.Web.Datastores.Migrations
{
    public partial class SeedingTestDataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Nvidia");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Intel");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Asus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Assorted Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Another Assorted Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Another Chocolate Candy");
        }
    }
}
