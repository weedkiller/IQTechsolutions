using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metsi.Web.Datastore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoNotCreateDocumentsFolder = table.Column<bool>(type: "bit", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
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
                name: "Department<Course>",
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
                    table.PrimaryKey("PK_Department<Course>", x => x.Id);
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Names_NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentElement<Course>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PointAllocation = table.Column<int>(type: "int", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElementType = table.Column<int>(type: "int", nullable: false),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentElement<Course>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentElement<Course>_Course_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Course>",
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
                    table.PrimaryKey("PK_ImageFile<Course>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Course>_Course_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleNr = table.Column<int>(type: "int", nullable: false),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoNotCreateDocumentsFolder = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Category<Course>",
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
                    table.PrimaryKey("PK_Category<Course>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category<Course>_Category<Course>_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category<Course>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category<Course>_Department<Course>_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department<Course>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Department<Course>>",
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
                    table.PrimaryKey("PK_ImageFile<Department<Course>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Department<Course>>_Department<Course>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Department<Course>",
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
                name: "Address<Student>",
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
                    table.PrimaryKey("PK_Address<Student>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address<Student>_Student_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumber<Student>",
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
                    table.PrimaryKey("PK_ContactNumber<Student>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumber<Student>_Student_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress<Student>",
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
                    table.PrimaryKey("PK_EmailAddress<Student>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddress<Student>_Student_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Student>",
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
                    table.PrimaryKey("PK_ImageFile<Student>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Student>_Student_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserInfo_Id",
                        column: x => x.Id,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EmailAddress<UserInfo>",
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
                    table.PrimaryKey("PK_EmailAddress<UserInfo>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddress<UserInfo>_UserInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<UserInfo>",
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
                    table.PrimaryKey("PK_ImageFile<UserInfo>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<UserInfo>_UserInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentElement<Module>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PointAllocation = table.Column<int>(type: "int", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElementType = table.Column<int>(type: "int", nullable: false),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentElement<Module>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentElement<Module>_Module_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Module>",
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
                    table.PrimaryKey("PK_ImageFile<Module>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Module>_Module_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SectionNr = table.Column<int>(type: "int", nullable: false),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoNotCreateDocumentsFolder = table.Column<bool>(type: "bit", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParentSectionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_Section_ParentSectionId",
                        column: x => x.ParentSectionId,
                        principalTable: "Section",
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
                name: "EntityCategory<Course>",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategory<Course>", x => new { x.EntityId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntityCategory<Course>_Category<Course>_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category<Course>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCategory<Course>_Course_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Category<Course>>",
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
                    table.PrimaryKey("PK_ImageFile<Category<Course>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Category<Course>>_Category<Course>_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Category<Course>",
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_EntityFeeling_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile<Section>",
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
                    table.PrimaryKey("PK_ImageFile<Section>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile<Section>_Section_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Section",
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
                name: "IX_Address<Customer>_EntityId",
                table: "Address<Customer>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address<Employee>_EntityId",
                table: "Address<Employee>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address<RecurringTask>_EntityId",
                table: "Address<RecurringTask>",
                column: "EntityId",
                unique: true,
                filter: "[EntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address<Student>_EntityId",
                table: "Address<Student>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentElement<Course>_EntityId",
                table: "AssessmentElement<Course>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentElement<Module>_EntityId",
                table: "AssessmentElement<Module>",
                column: "EntityId");

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
                name: "IX_Category<Course>_DepartmentId",
                table: "Category<Course>",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category<Course>_ParentCategoryId",
                table: "Category<Course>",
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
                name: "IX_ContactNumber<Student>_EntityId",
                table: "ContactNumber<Student>",
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
                name: "IX_EmailAddress<Student>_EntityId",
                table: "EmailAddress<Student>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress<UserInfo>_EntityId",
                table: "EmailAddress<UserInfo>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<BlogPost>_CategoryId",
                table: "EntityCategory<BlogPost>",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCategory<Course>_CategoryId",
                table: "EntityCategory<Course>",
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
                name: "IX_EntityFeeling_UserId",
                table: "EntityFeeling",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTask<Service>_TaskId",
                table: "EntityTask<Service>",
                column: "TaskId");

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
                name: "IX_ImageFile<Category<Course>>_EntityId",
                table: "ImageFile<Category<Course>>",
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
                name: "IX_ImageFile<Course>_EntityId",
                table: "ImageFile<Course>",
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
                name: "IX_ImageFile<Department<Course>>_EntityId",
                table: "ImageFile<Department<Course>>",
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
                name: "IX_ImageFile<Module>_EntityId",
                table: "ImageFile<Module>",
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
                name: "IX_ImageFile<Section>_EntityId",
                table: "ImageFile<Section>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Service>_EntityId",
                table: "ImageFile<Service>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<Student>_EntityId",
                table: "ImageFile<Student>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile<UserInfo>_EntityId",
                table: "ImageFile<UserInfo>",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedService<Service>_ServiceId",
                table: "IncludedService<Service>",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CourseId",
                table: "Module",
                column: "CourseId");

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
                name: "IX_Section_ModuleId",
                table: "Section",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ParentSectionId",
                table: "Section",
                column: "ParentSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_EmployeeId",
                table: "Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

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
                name: "Address<Customer>");

            migrationBuilder.DropTable(
                name: "Address<Employee>");

            migrationBuilder.DropTable(
                name: "Address<RecurringTask>");

            migrationBuilder.DropTable(
                name: "Address<Student>");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssessmentElement<Course>");

            migrationBuilder.DropTable(
                name: "AssessmentElement<Module>");

            migrationBuilder.DropTable(
                name: "ComboExclusions<Service>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Customer>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Employee>");

            migrationBuilder.DropTable(
                name: "ContactNumber<Student>");

            migrationBuilder.DropTable(
                name: "CorrectiveAction");

            migrationBuilder.DropTable(
                name: "EmailAddress<Customer>");

            migrationBuilder.DropTable(
                name: "EmailAddress<Employee>");

            migrationBuilder.DropTable(
                name: "EmailAddress<Student>");

            migrationBuilder.DropTable(
                name: "EmailAddress<UserInfo>");

            migrationBuilder.DropTable(
                name: "EntityCategory<BlogPost>");

            migrationBuilder.DropTable(
                name: "EntityCategory<Course>");

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
                name: "EntityTask<Service>");

            migrationBuilder.DropTable(
                name: "FormElement<RecurringTask>");

            migrationBuilder.DropTable(
                name: "ImageFile<BlogPost>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<BlogPost>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Course>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Problem>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Project>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Question>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Category<Service>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Course>");

            migrationBuilder.DropTable(
                name: "ImageFile<Customer>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<BlogPost>>");

            migrationBuilder.DropTable(
                name: "ImageFile<Department<Course>>");

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
                name: "ImageFile<Module>");

            migrationBuilder.DropTable(
                name: "ImageFile<Project>");

            migrationBuilder.DropTable(
                name: "ImageFile<Question>");

            migrationBuilder.DropTable(
                name: "ImageFile<Section>");

            migrationBuilder.DropTable(
                name: "ImageFile<Service>");

            migrationBuilder.DropTable(
                name: "ImageFile<Student>");

            migrationBuilder.DropTable(
                name: "ImageFile<UserInfo>");

            migrationBuilder.DropTable(
                name: "IncludedService<Service>");

            migrationBuilder.DropTable(
                name: "OptionalService<Service>");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ComboCategory<Service>");

            migrationBuilder.DropTable(
                name: "Cause");

            migrationBuilder.DropTable(
                name: "Comment<Service>");

            migrationBuilder.DropTable(
                name: "RecurringTask");

            migrationBuilder.DropTable(
                name: "Category<BlogPost>");

            migrationBuilder.DropTable(
                name: "Category<Course>");

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
                name: "Section");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Category<Service>");

            migrationBuilder.DropTable(
                name: "Problem");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Department<BlogPost>");

            migrationBuilder.DropTable(
                name: "Department<Course>");

            migrationBuilder.DropTable(
                name: "Department<Problem>");

            migrationBuilder.DropTable(
                name: "Department<Project>");

            migrationBuilder.DropTable(
                name: "Department<Question>");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Department<Service>");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "AudioFile<BlogPost>");
        }
    }
}
