using Microsoft.EntityFrameworkCore.Migrations;

namespace GoldTechInnovation.Web.Datastores.Migrations
{
    public partial class SeedingTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "1", null, "GPU" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "2", null, "CPU" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "3", null, "Motherboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "1", null, "1", "\\Images\\NvidiaRTX2060ti.jpg", "Assorted Chocolate Candy", 4.95m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "2", null, "2", "\\Images\\NvidiaRTX2060ti.jpg", "Another Assorted Chocolate Candy", 3.95m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "3", null, "3", "\\Images\\NvidiaRTX2060ti.jpg", "Another Chocolate Candy", 2.95m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
