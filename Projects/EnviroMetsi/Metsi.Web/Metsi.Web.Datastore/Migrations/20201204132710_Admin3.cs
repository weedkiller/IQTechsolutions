using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class Admin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNr",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MoodStatus",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveNewsletters",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveNotifications",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowContactInfo",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Title",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address<UserInfo>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Latitude = table.Column<double>(type: "float", nullable: true),
                    Location_Longitude = table.Column<double>(type: "float", nullable: true),
                    Raduis = table.Column<int>(type: "int", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address<UserInfo>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<UserInfo>_UserInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumber<UserInfo>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactNumber<UserInfo>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumber<UserInfo>_UserInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address<UserInfo>_EntityId",
                table: "Address<UserInfo>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumber<UserInfo>_EntityId",
                table: "ContactNumber<UserInfo>",
                column: "EntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address<UserInfo>");

            migrationBuilder.DropTable(
                name: "ContactNumber<UserInfo>");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "IdentityNr",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "MoodStatus",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "ReceiveNewsletters",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "ReceiveNotifications",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "ShowContactInfo",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserInfo");
        }
    }
}
