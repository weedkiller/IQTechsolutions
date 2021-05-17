using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQTechSolutions.DataStores.Migrations
{
    public partial class AddProcessingToGRV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioFile<CaseStudy>_CaseStudy_EntityId",
                table: "AudioFile<CaseStudy>");

            migrationBuilder.DropTable(
                name: "EntityCategory<CaseStudy>");

            migrationBuilder.DropTable(
                name: "ImageFile<CaseStudy>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<CaseStudy>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<CaseStudy>>");

            migrationBuilder.DropTable(
                name: "Category<CaseStudy>");

            migrationBuilder.DropTable(
                name: "Department<CaseStudy>");

            migrationBuilder.DropTable(
                name: "CaseStudy");

            migrationBuilder.DropTable(
                name: "AudioFile<CaseStudy>");

            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "GoodReceivedVoucherDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "GoodReceivedVoucher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Department<BlogPost>",
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
                    table.PrimaryKey("PK_Department<BlogPost>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category<BlogPost>",
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
                    table.PrimaryKey("PK_Category<BlogPost>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<BlogPost>_Category<BlogPost>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<BlogPost>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<BlogPost>_Department<BlogPost>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<BlogPost>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<BlogPost>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<BlogPost>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<BlogPost>>_Department<BlogPost>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<BlogPost>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<BlogPost>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<BlogPost>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<BlogPost>>_Category<BlogPost>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<BlogPost>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    SocialShares = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Reply = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioFileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioFile<BlogPost>",
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFile<BlogPost>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioFile<BlogPost>_BlogPost_EntityId",
                        column: x => x.EntityId,
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<BlogPost>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<BlogPost>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<BlogPost>_BlogPost_EntityId",
                        column: x => x.EntityId,
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<BlogPost>_Category<BlogPost>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<BlogPost>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<BlogPost>",
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
                    table.PrimaryKey("PK_ImageFile<BlogPost>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<BlogPost>_BlogPost_EntityId",
                        column: x => x.EntityId,
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile<BlogPost>_EntityId",
                table: "AudioFile<BlogPost>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_AudioFileId",
                table: "BlogPost",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<BlogPost>_DepartmentId",
                table: "Category<BlogPost>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<BlogPost>_ParentCategoryId",
                table: "Category<BlogPost>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<BlogPost>_CategoryId",
                table: "EntityCategory<BlogPost>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<BlogPost>_EntityId",
                table: "ImageFile<BlogPost>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<BlogPost>>_EntityId",
                table: "ImageFile<Category<BlogPost>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<BlogPost>>_EntityId",
                table: "ImageFile<Department<BlogPost>>",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_AudioFile<BlogPost>_AudioFileId",
                table: "BlogPost",
                column: "AudioFileId",
                principalTable: "AudioFile<BlogPost>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioFile<BlogPost>_BlogPost_EntityId",
                table: "AudioFile<BlogPost>");

            migrationBuilder.DropTable(
                name: "EntityCategory<BlogPost>");

            migrationBuilder.DropTable(
                name: "ImageFile<BlogPost>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<BlogPost>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<BlogPost>>");

            migrationBuilder.DropTable(
                name: "Category<BlogPost>");

            migrationBuilder.DropTable(
                name: "Department<BlogPost>");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "AudioFile<BlogPost>");

            migrationBuilder.DropColumn(
                name: "Processed",
                table: "GoodReceivedVoucherDetails");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "GoodReceivedVoucher");

            migrationBuilder.CreateTable(
                name: "Department<CaseStudy>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department<CaseStudy>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category<CaseStudy>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WebTags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category<CaseStudy>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<CaseStudy>_Category<CaseStudy>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<CaseStudy>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<CaseStudy>_Department<CaseStudy>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<CaseStudy>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<CaseStudy>>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Department<CaseStudy>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<CaseStudy>>_Department<CaseStudy>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<CaseStudy>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<CaseStudy>>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<Category<CaseStudy>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<CaseStudy>>_Category<CaseStudy>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<CaseStudy>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AudioFileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioFile<CaseStudy>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFile<CaseStudy>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioFile<CaseStudy>_CaseStudy_EntityId",
                        column: x => x.EntityId,
                        principalTable: "CaseStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<CaseStudy>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<CaseStudy>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<CaseStudy>_CaseStudy_EntityId",
                        column: x => x.EntityId,
                        principalTable: "CaseStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<CaseStudy>_Category<CaseStudy>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<CaseStudy>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<CaseStudy>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile<CaseStudy>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<CaseStudy>_CaseStudy_EntityId",
                        column: x => x.EntityId,
                        principalTable: "CaseStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile<CaseStudy>_EntityId",
                table: "AudioFile<CaseStudy>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStudy_AudioFileId",
                table: "CaseStudy",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<CaseStudy>_DepartmentId",
                table: "Category<CaseStudy>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<CaseStudy>_ParentCategoryId",
                table: "Category<CaseStudy>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<CaseStudy>_CategoryId",
                table: "EntityCategory<CaseStudy>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<CaseStudy>_EntityId",
                table: "ImageFile<CaseStudy>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<CaseStudy>>_EntityId",
                table: "ImageFile<Category<CaseStudy>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<CaseStudy>>_EntityId",
                table: "ImageFile<Department<CaseStudy>>",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStudy_AudioFile<CaseStudy>_AudioFileId",
                table: "CaseStudy",
                column: "AudioFileId",
                principalTable: "AudioFile<CaseStudy>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
