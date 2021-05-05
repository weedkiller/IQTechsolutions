using Microsoft.EntityFrameworkCore.Migrations;

namespace GoldTechInnovation.Web.Datastores.Migrations
{
    public partial class SeedingDbData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "\\Images\\GPU1.jpg", 5.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "1", "\\Images\\GPU2.jpg", "Nvidia", 50.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "1", "\\Images\\GPU3.jpg", "Nvidia", 500.95m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { "4", null, "2", "\\Images\\CPU1.jpg", "Intel", 30.95m },
                    { "5", null, "2", "\\Images\\CPU2.jpg", "Intel", 300.95m },
                    { "6", null, "2", "\\Images\\CPU3.jpg", "Intel", 3000.95m },
                    { "7", null, "3", "\\Images\\Motherboard1.jpg", "Asus", 20.95m },
                    { "8", null, "3", "\\Images\\Motherboard2.jpg", "Asus", 200.95m },
                    { "9", null, "3", "\\Images\\Motherboard3.jpg", "Asus", 2000.95m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "\\Images\\NvidiaRTX2060ti.jpg", 4.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "2", "\\Images\\NvidiaRTX2060ti.jpg", "Intel", 3.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { "3", "\\Images\\NvidiaRTX2060ti.jpg", "Asus", 2.95m });
        }
    }
}
