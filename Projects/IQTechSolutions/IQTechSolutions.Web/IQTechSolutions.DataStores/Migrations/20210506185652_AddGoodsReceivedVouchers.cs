using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQTechSolutions.DataStores.Migrations
{
    public partial class AddGoodsReceivedVouchers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodReceivedVoucher",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceivedVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceivedVoucher_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodReceivedVoucherDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriceExcl = table.Column<double>(type: "float", nullable: false),
                    PriceVat = table.Column<double>(type: "float", nullable: false),
                    PriceIncl = table.Column<double>(type: "float", nullable: false),
                    GoodReceivedVoucherId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceivedVoucherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceivedVoucherDetails_GoodReceivedVoucher_GoodReceivedVoucherId",
                        column: x => x.GoodReceivedVoucherId,
                        principalTable: "GoodReceivedVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodReceivedVoucherDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedVoucher_SupplierId",
                table: "GoodReceivedVoucher",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedVoucherDetails_GoodReceivedVoucherId",
                table: "GoodReceivedVoucherDetails",
                column: "GoodReceivedVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedVoucherDetails_ProductId",
                table: "GoodReceivedVoucherDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodReceivedVoucherDetails");

            migrationBuilder.DropTable(
                name: "GoodReceivedVoucher");
        }
    }
}
