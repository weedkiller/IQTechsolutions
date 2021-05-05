using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQTechSolutions.DataStores.Migrations
{
    public partial class AddProjectsModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment<Product>Id",
                table: "EntityFeeling",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department<Product>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department<Product>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    VatRate = table.Column<double>(type: "float", nullable: false),
                    CostExcl = table.Column<double>(type: "float", nullable: false),
                    PriceIncl = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    ListedItem = table.Column<bool>(type: "bit", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    QtyInStock = table.Column<int>(type: "int", nullable: false),
                    PackagingId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Product_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Brand>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Brand>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Brand>_Brand_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category<Product>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    WebTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category<Product>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Product>_Category<Product>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Product>_Department<Product>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Product>>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Department<Product>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Product>>_Department<Product>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment<Product>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDevice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentProductId = table.Column<string>(name: "Comment<Product>Id", type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment<Product>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment<Product>_Comment<Product>_Comment<Product>Id",
                        column: x => x.CommentProductId,
                        principalTable: "Comment<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Product>_Product_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Product>_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Product>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Product>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Product>_Product_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncludedProduct<Product>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedProduct<Product>", x => new { x.EntityId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_IncludedProduct<Product>_Product_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncludedProduct<Product>_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionalProduct<Product>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalProduct<Product>", x => new { x.EntityId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OptionalProduct<Product>_Product_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OptionalProduct<Product>_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => new { x.ProductId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_ProductBrand_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBrand_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboCategory<Product>",
                columns: table => new
                {
                    ComboItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboRecipyCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboCategory<Product>", x => new { x.ComboItemId, x.ComboRecipyCategoryId });
                    table.UniqueConstraint("AK_ComboCategory<Product>_ComboRecipyCategoryId", x => x.ComboRecipyCategoryId);
                    table.ForeignKey(
                        name: "FK_ComboCategory<Product>_Category<Product>_ComboRecipyCategoryId",
                        column: x => x.ComboRecipyCategoryId,
                        principalTable: "Category<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboCategory<Product>_Product_ComboItemId",
                        column: x => x.ComboItemId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Product>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Product>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Product>_Category<Product>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Product>_Product_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Product>>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Category<Product>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Product>>_Category<Product>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboExclusions<Product>",
                columns: table => new
                {
                    ExclusionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboCategoryComboRecipyCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboExclusions<Product>", x => new { x.ExclusionId, x.ComboCategoryId });
                    table.ForeignKey(
                        name: "FK_ComboExclusions<Product>_ComboCategory<Product>_ComboCategoryComboRecipyCategoryId",
                        column: x => x.ComboCategoryComboRecipyCategoryId,
                        principalTable: "ComboCategory<Product>",
                        principalColumn: "ComboRecipyCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComboExclusions<Product>_Product_ExclusionId",
                        column: x => x.ExclusionId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeeling_Comment<Product>Id",
                table: "EntityFeeling",
                column: "Comment<Product>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Product>_DepartmentId",
                table: "Category<Product>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Product>_ParentCategoryId",
                table: "Category<Product>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboExclusions<Product>_ComboCategoryComboRecipyCategoryId",
                table: "ComboExclusions<Product>",
                column: "ComboCategoryComboRecipyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Product>_Comment<Product>Id",
                table: "Comment<Product>",
                column: "Comment<Product>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Product>_EntityId",
                table: "Comment<Product>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Product>_UserId",
                table: "Comment<Product>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Product>_CategoryId",
                table: "EntityCategory<Product>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Brand>_EntityId",
                table: "ImageFile<Brand>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Product>>_EntityId",
                table: "ImageFile<Category<Product>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Product>>_EntityId",
                table: "ImageFile<Department<Product>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Product>_EntityId",
                table: "ImageFile<Product>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProduct<Product>_ProductId",
                table: "IncludedProduct<Product>",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalProduct<Product>_ProductId",
                table: "OptionalProduct<Product>",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PackagingId",
                table: "Product",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrand_BrandId",
                table: "ProductBrand",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityFeeling_Comment<Product>_Comment<Product>Id",
                table: "EntityFeeling",
                column: "Comment<Product>Id",
                principalTable: "Comment<Product>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityFeeling_Comment<Product>_Comment<Product>Id",
                table: "EntityFeeling");

            migrationBuilder.DropTable(
                name: "ComboExclusions<Product>");

            migrationBuilder.DropTable(
                name: "Comment<Product>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Product>");

            migrationBuilder.DropTable(
                name: "ImageFile<Brand>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Product>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Product>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Product>");

            migrationBuilder.DropTable(
                name: "IncludedProduct<Product>");

            migrationBuilder.DropTable(
                name: "OptionalProduct<Product>");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ComboCategory<Product>");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category<Product>");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Department<Product>");

            migrationBuilder.DropIndex(
                name: "IX_EntityFeeling_Comment<Product>Id",
                table: "EntityFeeling");

            migrationBuilder.DropColumn(
                name: "Comment<Product>Id",
                table: "EntityFeeling");
        }
    }
}
