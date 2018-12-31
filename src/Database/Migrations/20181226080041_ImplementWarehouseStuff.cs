using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ImplementWarehouseStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.EnsureSchema(
                name: "share");

            migrationBuilder.EnsureSchema(
                name: "static");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PhotoId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    HoldingName = table.Column<string>(maxLength: 256, nullable: false),
                    HoldingNameEn = table.Column<string>(maxLength: 256, nullable: true),
                    HoldingLogo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    LogTypeName = table.Column<string>(maxLength: 256, nullable: false),
                    LogTypeEnName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementAppMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppMenuId = table.Column<int>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 256, nullable: false),
                    MenuClass = table.Column<string>(maxLength: 256, nullable: false),
                    MenuUrl = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementAppMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementAppMenus_ManagementAppMenus_AppMenuId",
                        column: x => x.AppMenuId,
                        principalTable: "ManagementAppMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PermissionParentId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Text = table.Column<string>(maxLength: 256, nullable: true),
                    Key = table.Column<string>(maxLength: 256, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SateIsPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Permission_PermissionParentId",
                        column: x => x.PermissionParentId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StuffGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ManualCode = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 256, nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuffGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StuffUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuffUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ManualCode = table.Column<int>(nullable: false),
                    Nature = table.Column<string>(nullable: true),
                    ActivityCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetworkInfos",
                schema: "share",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(maxLength: 50, nullable: false),
                    Port = table.Column<int>(nullable: false),
                    Mac = table.Column<string>(maxLength: 29, nullable: false),
                    HostName = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseInfoGroups",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    BaseInfoGroupName = table.Column<string>(maxLength: 256, nullable: false),
                    BaseInfoGroupText = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfoGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ISO = table.Column<string>(maxLength: 2, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: true),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: true),
                    CountryCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PersonGroupId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 20, nullable: false),
                    PhotoId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PersonGroups_PersonGroupId",
                        column: x => x.PersonGroupId,
                        principalTable: "PersonGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stuffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ManualCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: true),
                    ShortName = table.Column<string>(maxLength: 256, nullable: true),
                    StuffGroupId = table.Column<int>(nullable: false),
                    StuffUnitId = table.Column<int>(nullable: false),
                    WebUrl = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stuffs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stuffs_StuffGroups_StuffGroupId",
                        column: x => x.StuffGroupId,
                        principalTable: "StuffGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stuffs_StuffUnits_StuffUnitId",
                        column: x => x.StuffUnitId,
                        principalTable: "StuffUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UserGroupId = table.Column<int>(nullable: false),
                    RoleGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupRoles_RoleGroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupRoles_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UserGroupId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PhoneNumberCount = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(nullable: true),
                    LegalName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    NetworkInfoId = table.Column<int>(nullable: false),
                    PhotoId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_NetworkInfos_NetworkInfoId",
                        column: x => x.NetworkInfoId,
                        principalSchema: "share",
                        principalTable: "NetworkInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseInfos",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    BaseInfoGroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    LatinName = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseInfos_BaseInfoGroups_BaseInfoGroupId",
                        column: x => x.BaseInfoGroupId,
                        principalSchema: "static",
                        principalTable: "BaseInfoGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CurrencyName = table.Column<string>(maxLength: 256, nullable: false),
                    Symbol = table.Column<string>(maxLength: 10, nullable: false),
                    DecimalCount = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "static",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "static",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    BarcodeStuff = table.Column<string>(nullable: false),
                    StuffId = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarCodes_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceConsumers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StuffId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceConsumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceConsumers_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StuffSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StuffId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuffSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StuffSuppliers_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StuffSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawers_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    RelativeId = table.Column<string>(nullable: true),
                    RelativeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_RelativeId1",
                        column: x => x.RelativeId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    MeasureId = table.Column<int>(nullable: true),
                    NetworkInfoId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CommercialCode = table.Column<int>(nullable: false),
                    RegisterCode = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_NetworkInfos_NetworkInfoId",
                        column: x => x.NetworkInfoId,
                        principalSchema: "share",
                        principalTable: "NetworkInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    BaseInfoIntroductionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_BaseInfos_BaseInfoIntroductionId",
                        column: x => x.BaseInfoIntroductionId,
                        principalSchema: "static",
                        principalTable: "BaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BaseInfoActionCode = table.Column<string>(nullable: false),
                    BaseInfoId = table.Column<int>(nullable: true),
                    ManualCode = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_BaseInfos_BaseInfoId",
                        column: x => x.BaseInfoId,
                        principalSchema: "static",
                        principalTable: "BaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Class = table.Column<string>(maxLength: 256, nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentGroups_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "static",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentGroups_PersonGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PersonGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "static",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "static",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchGallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Photo = table.Column<byte[]>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchGallery_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashDesks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NetworkInfoId = table.Column<int>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDesks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashDesks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashDesks_NetworkInfos_NetworkInfoId",
                        column: x => x.NetworkInfoId,
                        principalSchema: "share",
                        principalTable: "NetworkInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCashDesks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCashDesks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCashDesks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCashDesks_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseStuffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StuffId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseStuffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseStuffs_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseStuffs_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawerPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PaymentGroupId = table.Column<int>(nullable: false),
                    DrawerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawerPayments_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "Drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawerPayments_PaymentGroups_PaymentGroupId",
                        column: x => x.PaymentGroupId,
                        principalTable: "PaymentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchContacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldingContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    HoldingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingContacts_Holdings_HoldingId",
                        column: x => x.HoldingId,
                        principalTable: "Holdings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierContacts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseContacts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseContacts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceTags",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    StuffId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTags_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceTags_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "static",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceTags_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                schema: "share",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BaseInfoTargetId = table.Column<int>(nullable: false),
                    MainName = table.Column<string>(maxLength: 256, nullable: false),
                    NetworkInfoId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 256, nullable: false),
                    Model = table.Column<string>(maxLength: 256, nullable: false),
                    BaseInfoColorId = table.Column<int>(nullable: false),
                    BaseInfoNatureId = table.Column<int>(nullable: false),
                    CashDeskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilities_CashDesks_CashDeskId",
                        column: x => x.CashDeskId,
                        principalTable: "CashDesks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utilities_NetworkInfos_NetworkInfoId",
                        column: x => x.NetworkInfoId,
                        principalSchema: "share",
                        principalTable: "NetworkInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashDeskUtilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CashDeskId = table.Column<int>(nullable: true),
                    UtilityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDeskUtilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashDeskUtilities_CashDesks_CashDeskId",
                        column: x => x.CashDeskId,
                        principalTable: "CashDesks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashDeskUtilities_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalSchema: "share",
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UtilityDetails",
                schema: "share",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(nullable: false),
                    ModByUserId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UtilityId = table.Column<int>(nullable: false),
                    Property = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilityDetails_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalSchema: "share",
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarCodes_StuffId",
                table: "BarCodes",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchContacts_BranchId",
                table: "BranchContacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchContacts_CityId",
                table: "BranchContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_MeasureId",
                table: "Branches",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_NetworkInfoId",
                table: "Branches",
                column: "NetworkInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchGallery_BranchId",
                table: "BranchGallery",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashDesks_BranchId",
                table: "CashDesks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashDesks_NetworkInfoId",
                table: "CashDesks",
                column: "NetworkInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CashDeskUtilities_CashDeskId",
                table: "CashDeskUtilities",
                column: "CashDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_CashDeskUtilities_UtilityId",
                table: "CashDeskUtilities",
                column: "UtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_NetworkInfoId",
                table: "Companies",
                column: "NetworkInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_CityId",
                table: "CompanyContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_CompanyId",
                table: "CompanyContacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BaseInfoIntroductionId",
                table: "Customers",
                column: "BaseInfoIntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonId",
                table: "Customers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerPayments_DrawerId",
                table: "DrawerPayments",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerPayments_PaymentGroupId",
                table: "DrawerPayments",
                column: "PaymentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_OwnerUserId",
                table: "Drawers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingContacts_CityId",
                table: "HoldingContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingContacts_HoldingId",
                table: "HoldingContacts",
                column: "HoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementAppMenus_AppMenuId",
                table: "ManagementAppMenus",
                column: "AppMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGroups_CurrencyId",
                table: "PaymentGroups",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGroups_ParentId",
                table: "PaymentGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionParentId",
                table: "Permission",
                column: "PermissionParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_CityId",
                table: "PersonContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId",
                table: "PersonContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonGroupId",
                table: "Persons",
                column: "PersonGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceConsumers_StuffId",
                table: "PriceConsumers",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Stuffs_BrandId",
                table: "Stuffs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Stuffs_StuffGroupId",
                table: "Stuffs",
                column: "StuffGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Stuffs_StuffUnitId",
                table: "Stuffs",
                column: "StuffUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StuffSuppliers_StuffId",
                table: "StuffSuppliers",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_StuffSuppliers_SupplierId",
                table: "StuffSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContacts_CityId",
                table: "SupplierContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContacts_SupplierId",
                table: "SupplierContacts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCashDesks_BranchId",
                table: "UserCashDesks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCashDesks_RoleId",
                table: "UserCashDesks",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupRoles_RoleGroupId",
                table: "UserGroupRoles",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupRoles_UserGroupId",
                table: "UserGroupRoles",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RelativeId1",
                table: "UserRoles",
                column: "RelativeId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseContacts_CityId",
                table: "WarehouseContacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseContacts_WarehouseId",
                table: "WarehouseContacts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_BaseInfoId",
                table: "Warehouses",
                column: "BaseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_MeasureId",
                table: "Warehouses",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseStuffs_StuffId",
                table: "WarehouseStuffs",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseStuffs_WarehouseId",
                table: "WarehouseStuffs",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTags_BranchId",
                schema: "sale",
                table: "PriceTags",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTags_CityId",
                schema: "sale",
                table: "PriceTags",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTags_StuffId",
                schema: "sale",
                table: "PriceTags",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilities_CashDeskId",
                schema: "share",
                table: "Utilities",
                column: "CashDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilities_NetworkInfoId",
                schema: "share",
                table: "Utilities",
                column: "NetworkInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityDetails_UtilityId",
                schema: "share",
                table: "UtilityDetails",
                column: "UtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseInfos_BaseInfoGroupId",
                schema: "static",
                table: "BaseInfos",
                column: "BaseInfoGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "static",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CountryId",
                schema: "static",
                table: "Currencies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                schema: "static",
                table: "Provinces",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarCodes");

            migrationBuilder.DropTable(
                name: "BranchContacts");

            migrationBuilder.DropTable(
                name: "BranchGallery");

            migrationBuilder.DropTable(
                name: "CashDeskUtilities");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DrawerPayments");

            migrationBuilder.DropTable(
                name: "HoldingContacts");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "ManagementAppMenus");

            migrationBuilder.DropTable(
                name: "PersonContacts");

            migrationBuilder.DropTable(
                name: "PriceConsumers");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "StuffSuppliers");

            migrationBuilder.DropTable(
                name: "SupplierContacts");

            migrationBuilder.DropTable(
                name: "UserCashDesks");

            migrationBuilder.DropTable(
                name: "UserGroupRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WarehouseContacts");

            migrationBuilder.DropTable(
                name: "WarehouseStuffs");

            migrationBuilder.DropTable(
                name: "PriceTags",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "UtilityDetails",
                schema: "share");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "PaymentGroups");

            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "RoleGroups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "static");

            migrationBuilder.DropTable(
                name: "Stuffs");

            migrationBuilder.DropTable(
                name: "Utilities",
                schema: "share");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "static");

            migrationBuilder.DropTable(
                name: "PersonGroups");

            migrationBuilder.DropTable(
                name: "BaseInfos",
                schema: "static");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "static");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "StuffGroups");

            migrationBuilder.DropTable(
                name: "StuffUnits");

            migrationBuilder.DropTable(
                name: "CashDesks");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "BaseInfoGroups",
                schema: "static");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "static");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "NetworkInfos",
                schema: "share");
        }
    }
}
