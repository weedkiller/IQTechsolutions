using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswer<Course>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AssessmentElementId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswer<Course>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswer<Course>_AssessmentElement<Course>_AssessmentElementId",
                        column: x => x.AssessmentElementId,
                        principalTable: "AssessmentElement<Course>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswer<Module>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AssessmentElementId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswer<Module>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswer<Module>_AssessmentElement<Module>_AssessmentElementId",
                        column: x => x.AssessmentElementId,
                        principalTable: "AssessmentElement<Module>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswer<Course>_AssessmentElementId",
                table: "MultipleChoiceAnswer<Course>",
                column: "AssessmentElementId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswer<Module>_AssessmentElementId",
                table: "MultipleChoiceAnswer<Module>",
                column: "AssessmentElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswer<Course>");

            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswer<Module>");
        }
    }
}
