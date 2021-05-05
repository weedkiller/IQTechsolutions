using Microsoft.EntityFrameworkCore.Migrations;

namespace IQTechSolutions.DataStores.Migrations
{
    public partial class AddSerialNrToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Product");
        }
    }
}
