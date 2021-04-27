using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympia.Web.DataStore.Migrations
{
    public partial class Admin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserInfo_UserInfoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserInfoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecurrenceRule = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

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
                name: "Department<Event>",
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
                    table.PrimaryKey("PK_Department<Event>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department<Problem>",
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
                    table.PrimaryKey("PK_Department<Problem>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department<Project>",
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
                    table.PrimaryKey("PK_Department<Project>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department<Question>",
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
                    table.PrimaryKey("PK_Department<Question>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department<Service>",
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
                    table.PrimaryKey("PK_Department<Service>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Names_NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    WorkTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkedForDeletion = table.Column<bool>(type: "bit", nullable: false),
                    IdentityNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationAccessLevel = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
                    SocialMedia_WebSiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia_Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia_Google = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia_Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia_Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia_Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserInfoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeed",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDevice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParentFeedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsFeed_NewsFeed_ParentFeedId",
                        column: x => x.ParentFeedId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsFeed_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCustomPage = table.Column<bool>(type: "bit", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SharedProjectFolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Project_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecurringTask",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IconString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskPriority = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListedCalendarItem = table.Column<bool>(type: "bit", nullable: false),
                    EstimatedCompletionTime = table.Column<double>(type: "float", nullable: false),
                    ParentTaskId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringTask_RecurringTask_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "RecurringTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Route",
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
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingFrequency = table.Column<int>(type: "int", nullable: false),
                    ServiceFrequency = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceTableItem = table.Column<bool>(type: "bit", nullable: false),
                    Popular = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Module = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportTicket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    ParentTicketId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicket_SupportTicket_ParentTicketId",
                        column: x => x.ParentTicketId,
                        principalTable: "SupportTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address<Customer>",
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
                    table.PrimaryKey("PK_Address<Customer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<Customer>_Customer_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumber<Customer>",
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
                    table.PrimaryKey("PK_ContactNumber<Customer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumber<Customer>_Customer_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress<Customer>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_EmailAddress<Customer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddress<Customer>_Customer_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Customer>",
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
                    table.PrimaryKey("PK_ImageFile<Customer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Customer>_Customer_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Category<Event>",
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
                    table.PrimaryKey("PK_Category<Event>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Event>_Category<Event>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Event>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Event>_Department<Event>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Event>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Event>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Event>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Event>>_Department<Event>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Event>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category<Problem>",
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
                    table.PrimaryKey("PK_Category<Problem>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Problem>_Category<Problem>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Problem>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Problem>_Department<Problem>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Problem>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Problem>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Problem>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Problem>>_Department<Problem>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Problem>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category<Project>",
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
                    table.PrimaryKey("PK_Category<Project>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Project>_Category<Project>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Project>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Project>_Department<Project>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Project>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Project>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Project>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Project>>_Department<Project>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Project>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category<Question>",
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
                    table.PrimaryKey("PK_Category<Question>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Question>_Category<Question>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Question>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Question>_Department<Question>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Question>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Question>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Question>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Question>>_Department<Question>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Question>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category<Service>",
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
                    table.PrimaryKey("PK_Category<Service>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Service>_Category<Service>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Service>_Department<Service>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Service>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Service>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Service>>_Department<Service>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address<Employee>",
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
                    table.PrimaryKey("PK_Address<Employee>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<Employee>_Employee_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumber<Employee>",
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
                    table.PrimaryKey("PK_ContactNumber<Employee>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumber<Employee>_Employee_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress<Employee>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_EmailAddress<Employee>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddress<Employee>_Employee_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Employee>",
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
                    table.PrimaryKey("PK_ImageFile<Employee>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Employee>_Employee_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AudioFile<NewsFeed>",
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
                    table.PrimaryKey("PK_AudioFile<NewsFeed>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioFile<NewsFeed>_NewsFeed_EntityId",
                        column: x => x.EntityId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File<NewsFeed>",
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
                    table.PrimaryKey("PK_File<NewsFeed>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File<NewsFeed>_NewsFeed_EntityId",
                        column: x => x.EntityId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<NewsFeed>",
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
                    table.PrimaryKey("PK_ImageFile<NewsFeed>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<NewsFeed>_NewsFeed_EntityId",
                        column: x => x.EntityId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video<NewsFeed>",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: true),
                    IFrameString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video<NewsFeed>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video<NewsFeed>_NewsFeed_EntityId",
                        column: x => x.EntityId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cause",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cause", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cause_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Project>",
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
                    table.PrimaryKey("PK_ImageFile<Project>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Project>_Project_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnswerString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Question>",
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
                    table.PrimaryKey("PK_ImageFile<Question>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Question>_Question_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address<RecurringTask>",
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
                    table.PrimaryKey("PK_Address<RecurringTask>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<RecurringTask>_RecurringTask_EntityId",
                        column: x => x.EntityId,
                        principalTable: "RecurringTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormElement<RecurringTask>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ElementType = table.Column<int>(type: "int", nullable: false),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormElement<RecurringTask>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormElement<RecurringTask>_RecurringTask_EntityId",
                        column: x => x.EntityId,
                        principalTable: "RecurringTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteLocation_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment<Service>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDevice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentServiceId = table.Column<string>(name: "Comment<Service>Id", type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment<Service>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment<Service>_Comment<Service>_Comment<Service>Id",
                        column: x => x.CommentServiceId,
                        principalTable: "Comment<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Service>_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityTask<Service>",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTask<Service>", x => new { x.EntityId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_EntityTask<Service>_RecurringTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "RecurringTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTask<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Service>",
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
                    table.PrimaryKey("PK_ImageFile<Service>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncludedService<Service>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedService<Service>", x => new { x.EntityId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_IncludedService<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncludedService<Service>_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionalService<Service>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalService<Service>", x => new { x.EntityId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_OptionalService<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OptionalService<Service>_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File<SupportTicket>",
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
                    table.PrimaryKey("PK_File<SupportTicket>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File<SupportTicket>_SupportTicket_EntityId",
                        column: x => x.EntityId,
                        principalTable: "SupportTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Testimonial>",
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
                    table.PrimaryKey("PK_ImageFile<Testimonial>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Testimonial>_Testimonial_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Testimonial",
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
                name: "ImageFile<Category<Event>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Event>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Event>>_Category<Event>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Event>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Problem>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Problem>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Problem>_Category<Problem>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Problem>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Problem>_Problem_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Problem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Problem>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Problem>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Problem>>_Category<Problem>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Problem>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Project>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Project>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Project>_Category<Project>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Project>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Project>_Project_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Project>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Project>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Project>>_Category<Project>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Project>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Question>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Question>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Question>_Category<Question>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Question>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Question>_Question_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Question>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Question>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Question>>_Category<Question>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Question>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboCategory<Service>",
                columns: table => new
                {
                    ComboItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboRecipyCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboCategory<Service>", x => new { x.ComboItemId, x.ComboRecipyCategoryId });
                    table.UniqueConstraint("AK_ComboCategory<Service>_ComboRecipyCategoryId", x => x.ComboRecipyCategoryId);
                    table.ForeignKey(
                        name: "FK_ComboCategory<Service>_Category<Service>_ComboRecipyCategoryId",
                        column: x => x.ComboRecipyCategoryId,
                        principalTable: "Category<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboCategory<Service>_Service_ComboItemId",
                        column: x => x.ComboItemId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Service>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Service>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Service>_Category<Service>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Service>_Service_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Service>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Service>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Service>>_Category<Service>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveAction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProblemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveAction_Cause_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Cause",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectiveAction_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address<RouteLocation>",
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
                    table.PrimaryKey("PK_Address<RouteLocation>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<RouteLocation>_RouteLocation_EntityId",
                        column: x => x.EntityId,
                        principalTable: "RouteLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityTask<RouteLocation>",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTask<RouteLocation>", x => new { x.EntityId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_EntityTask<RouteLocation>_RecurringTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "RecurringTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTask<RouteLocation>_RouteLocation_EntityId",
                        column: x => x.EntityId,
                        principalTable: "RouteLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityFeeling",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Feeling = table.Column<int>(type: "int", nullable: false),
                    CommentServiceId = table.Column<string>(name: "Comment<Service>Id", type: "nvarchar(450)", nullable: true),
                    NewsFeedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFeeling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFeeling_Comment<Service>_Comment<Service>Id",
                        column: x => x.CommentServiceId,
                        principalTable: "Comment<Service>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFeeling_NewsFeed_NewsFeedId",
                        column: x => x.NewsFeedId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFeeling_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboExclusions<Service>",
                columns: table => new
                {
                    ExclusionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboCategoryComboRecipyCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboExclusions<Service>", x => new { x.ExclusionId, x.ComboCategoryId });
                    table.ForeignKey(
                        name: "FK_ComboExclusions<Service>_ComboCategory<Service>_ComboCategoryComboRecipyCategoryId",
                        column: x => x.ComboCategoryComboRecipyCategoryId,
                        principalTable: "ComboCategory<Service>",
                        principalColumn: "ComboRecipyCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComboExclusions<Service>_Service_ExclusionId",
                        column: x => x.ExclusionId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecurrenceRule = table.Column<int>(type: "int", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address<Event>",
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
                    table.PrimaryKey("PK_Address<Event>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<Event>_Event_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumber<Event>",
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
                    table.PrimaryKey("PK_ContactNumber<Event>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumber<Event>_Event_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCategory<Event>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Event>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Event>_Category<Event>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Event>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Event>_Event_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attendees = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRegistration_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Event>",
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
                    table.PrimaryKey("PK_ImageFile<Event>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Event>_Event_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video<Event>",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: true),
                    IFrameString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video<Event>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video<Event>_Event_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventDay",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EventRegistrationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDay_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventDay_EventRegistration_EventRegistrationId",
                        column: x => x.EventRegistrationId,
                        principalTable: "EventRegistration",
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
                name: "IX_UserInfo_EmployeeId",
                table: "UserInfo",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address<Customer>_EntityId",
                table: "Address<Customer>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address<Employee>_EntityId",
                table: "Address<Employee>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address<Event>_EntityId",
                table: "Address<Event>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address<RecurringTask>_EntityId",
                table: "Address<RecurringTask>",
                column: "EntityId",
                unique: true,
                filter: "[EntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address<RouteLocation>_EntityId",
                table: "Address<RouteLocation>",
                column: "EntityId",
                unique: true,
                filter: "[EntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile<BlogPost>_EntityId",
                table: "AudioFile<BlogPost>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile<NewsFeed>_EntityId",
                table: "AudioFile<NewsFeed>",
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
                name: "IX_Category<Event>_DepartmentId",
                table: "Category<Event>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Event>_ParentCategoryId",
                table: "Category<Event>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Problem>_DepartmentId",
                table: "Category<Problem>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Problem>_ParentCategoryId",
                table: "Category<Problem>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Project>_DepartmentId",
                table: "Category<Project>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Project>_ParentCategoryId",
                table: "Category<Project>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Question>_DepartmentId",
                table: "Category<Question>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Question>_ParentCategoryId",
                table: "Category<Question>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Service>_DepartmentId",
                table: "Category<Service>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Service>_ParentCategoryId",
                table: "Category<Service>",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cause_ProblemId",
                table: "Cause",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboExclusions<Service>_ComboCategoryComboRecipyCategoryId",
                table: "ComboExclusions<Service>",
                column: "ComboCategoryComboRecipyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Service>_Comment<Service>Id",
                table: "Comment<Service>",
                column: "Comment<Service>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Service>_EntityId",
                table: "Comment<Service>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Service>_UserId",
                table: "Comment<Service>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumber<Customer>_EntityId",
                table: "ContactNumber<Customer>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumber<Employee>_EntityId",
                table: "ContactNumber<Employee>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumber<Event>_EntityId",
                table: "ContactNumber<Event>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAction_CauseId",
                table: "CorrectiveAction",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAction_ProblemId",
                table: "CorrectiveAction",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress<Customer>_EntityId",
                table: "EmailAddress<Customer>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress<Employee>_EntityId",
                table: "EmailAddress<Employee>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<BlogPost>_CategoryId",
                table: "EntityCategory<BlogPost>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Event>_CategoryId",
                table: "EntityCategory<Event>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Problem>_CategoryId",
                table: "EntityCategory<Problem>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Project>_CategoryId",
                table: "EntityCategory<Project>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Question>_CategoryId",
                table: "EntityCategory<Question>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Service>_CategoryId",
                table: "EntityCategory<Service>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeeling_Comment<Service>Id",
                table: "EntityFeeling",
                column: "Comment<Service>Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeeling_NewsFeedId",
                table: "EntityFeeling",
                column: "NewsFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFeeling_UserId",
                table: "EntityFeeling",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTask<RouteLocation>_TaskId",
                table: "EntityTask<RouteLocation>",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTask<Service>_TaskId",
                table: "EntityTask<Service>",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDay_EventId",
                table: "EventDay",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDay_EventRegistrationId",
                table: "EventDay",
                column: "EventRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventId",
                table: "EventRegistration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_File<NewsFeed>_EntityId",
                table: "File<NewsFeed>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_File<SupportTicket>_EntityId",
                table: "File<SupportTicket>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FormElement<RecurringTask>_EntityId",
                table: "FormElement<RecurringTask>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<BlogPost>_EntityId",
                table: "ImageFile<BlogPost>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<BlogPost>>_EntityId",
                table: "ImageFile<Category<BlogPost>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Event>>_EntityId",
                table: "ImageFile<Category<Event>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Problem>>_EntityId",
                table: "ImageFile<Category<Problem>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Project>>_EntityId",
                table: "ImageFile<Category<Project>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Question>>_EntityId",
                table: "ImageFile<Category<Question>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Category<Service>>_EntityId",
                table: "ImageFile<Category<Service>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Customer>_EntityId",
                table: "ImageFile<Customer>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<BlogPost>>_EntityId",
                table: "ImageFile<Department<BlogPost>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Event>>_EntityId",
                table: "ImageFile<Department<Event>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Problem>>_EntityId",
                table: "ImageFile<Department<Problem>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Project>>_EntityId",
                table: "ImageFile<Department<Project>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Question>>_EntityId",
                table: "ImageFile<Department<Question>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Department<Service>>_EntityId",
                table: "ImageFile<Department<Service>>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Employee>_EntityId",
                table: "ImageFile<Employee>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Event>_EntityId",
                table: "ImageFile<Event>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<NewsFeed>_EntityId",
                table: "ImageFile<NewsFeed>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Project>_EntityId",
                table: "ImageFile<Project>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Question>_EntityId",
                table: "ImageFile<Question>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Service>_EntityId",
                table: "ImageFile<Service>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Testimonial>_EntityId",
                table: "ImageFile<Testimonial>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedService<Service>_ServiceId",
                table: "IncludedService<Service>",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_ParentFeedId",
                table: "NewsFeed",
                column: "ParentFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_UserId",
                table: "NewsFeed",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalService<Service>_ServiceId",
                table: "OptionalService<Service>",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ParentProjectId",
                table: "Project",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTask_ParentTaskId",
                table: "RecurringTask",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteLocation_RouteId",
                table: "RouteLocation",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_EmployeeId",
                table: "Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_ParentTicketId",
                table: "SupportTicket",
                column: "ParentTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Video<Event>_EntityId",
                table: "Video<Event>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Video<NewsFeed>_EntityId",
                table: "Video<NewsFeed>",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserInfo_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Employee_EmployeeId",
                table: "UserInfo",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Address<Event>_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Address<Event>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AspNetUsers_UserInfo_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Employee_EmployeeId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Address<Event>_Event_EntityId",
                table: "Address<Event>");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioFile<BlogPost>_BlogPost_EntityId",
                table: "AudioFile<BlogPost>");

            migrationBuilder.DropTable(
                name: "Address<Customer>");

            migrationBuilder.DropTable(
                name: "Address<Employee>");

            migrationBuilder.DropTable(
                name: "Address<RecurringTask>");

            migrationBuilder.DropTable(
                name: "Address<RouteLocation>");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AudioFile<NewsFeed>");

            migrationBuilder.DropTable(
                name: "ComboExclusions<Service>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Customer>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Employee>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Event>");

            migrationBuilder.DropTable(
                name: "CorrectiveAction");

            migrationBuilder.DropTable(
                name: "EmailAddress<Customer>");

            migrationBuilder.DropTable(
                name: "EmailAddress<Employee>");

            migrationBuilder.DropTable(
                name: "EntityCategory<BlogPost>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Event>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Problem>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Project>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Question>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Service>");

            migrationBuilder.DropTable(
                name: "EntityFeeling");

            migrationBuilder.DropTable(
                name: "EntityTask<RouteLocation>");

            migrationBuilder.DropTable(
                name: "EntityTask<Service>");

            migrationBuilder.DropTable(
                name: "EventDay");

            migrationBuilder.DropTable(
                name: "File<NewsFeed>");

            migrationBuilder.DropTable(
                name: "File<SupportTicket>");

            migrationBuilder.DropTable(
                name: "FormElement<RecurringTask>");

            migrationBuilder.DropTable(
                name: "ImageFile<BlogPost>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<BlogPost>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Event>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Problem>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Project>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Question>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Service>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Customer>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<BlogPost>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Event>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Problem>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Project>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Question>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Service>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Employee>");

            migrationBuilder.DropTable(
                name: "ImageFile<Event>");

            migrationBuilder.DropTable(
                name: "ImageFile<NewsFeed>");

            migrationBuilder.DropTable(
                name: "ImageFile<Project>");

            migrationBuilder.DropTable(
                name: "ImageFile<Question>");

            migrationBuilder.DropTable(
                name: "ImageFile<Service>");

            migrationBuilder.DropTable(
                name: "ImageFile<Testimonial>");

            migrationBuilder.DropTable(
                name: "IncludedService<Service>");

            migrationBuilder.DropTable(
                name: "OptionalService<Service>");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Video<Event>");

            migrationBuilder.DropTable(
                name: "Video<NewsFeed>");

            migrationBuilder.DropTable(
                name: "ComboCategory<Service>");

            migrationBuilder.DropTable(
                name: "Cause");

            migrationBuilder.DropTable(
                name: "Comment<Service>");

            migrationBuilder.DropTable(
                name: "RouteLocation");

            migrationBuilder.DropTable(
                name: "EventRegistration");

            migrationBuilder.DropTable(
                name: "SupportTicket");

            migrationBuilder.DropTable(
                name: "RecurringTask");

            migrationBuilder.DropTable(
                name: "Category<BlogPost>");

            migrationBuilder.DropTable(
                name: "Category<Event>");

            migrationBuilder.DropTable(
                name: "Category<Problem>");

            migrationBuilder.DropTable(
                name: "Category<Project>");

            migrationBuilder.DropTable(
                name: "Category<Question>");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Testimonial");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "NewsFeed");

            migrationBuilder.DropTable(
                name: "Category<Service>");

            migrationBuilder.DropTable(
                name: "Problem");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Department<BlogPost>");

            migrationBuilder.DropTable(
                name: "Department<Event>");

            migrationBuilder.DropTable(
                name: "Department<Problem>");

            migrationBuilder.DropTable(
                name: "Department<Project>");

            migrationBuilder.DropTable(
                name: "Department<Question>");

            migrationBuilder.DropTable(
                name: "Department<Service>");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Address<Event>");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "AudioFile<BlogPost>");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_EmployeeId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserInfoId",
                table: "AspNetUsers",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserInfo_UserInfoId",
                table: "AspNetUsers",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
