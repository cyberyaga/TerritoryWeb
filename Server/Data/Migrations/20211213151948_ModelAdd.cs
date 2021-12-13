using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritoryWeb.Server.Data.Migrations
{
    public partial class ModelAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Congregations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URLMinimizeStore",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    shortURL = table.Column<string>(type: "TEXT", nullable: false),
                    longURL = table.Column<string>(type: "TEXT", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    used = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLMinimizeStore", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DoorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CongregationID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorCodes_Congregations_CongregationID",
                        column: x => x.CongregationID,
                        principalTable: "Congregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CongregationID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Congregations_CongregationID",
                        column: x => x.CongregationID,
                        principalTable: "Congregations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerritoryName = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CongregationID = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedPublisherID = table.Column<string>(type: "TEXT", nullable: true),
                    AddedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Added = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckedOut = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CheckedIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastCheckedInBy = table.Column<string>(type: "TEXT", nullable: true),
                    TerritoryTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Territories_Congregations_CongregationID",
                        column: x => x.CongregationID,
                        principalTable: "Congregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Territories_TerritoryTypes_TerritoryTypeId",
                        column: x => x.TerritoryTypeId,
                        principalTable: "TerritoryTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerritoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Apartment = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageID = table.Column<int>(type: "INTEGER", nullable: true),
                    DoorCodeID = table.Column<int>(type: "INTEGER", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    GeoLat = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    GeoLong = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    AddedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Added = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_DoorCodes_DoorCodeID",
                        column: x => x.DoorCodeID,
                        principalTable: "DoorCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doors_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doors_Territories_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerritoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWrite = table.Column<bool>(type: "INTEGER", nullable: false),
                    TempAccess = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerritoryAccess_Territories_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryBounds",
                columns: table => new
                {
                    BoundaryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerritoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    GeoLat = table.Column<decimal>(type: "decimal(9, 6)", nullable: false),
                    GeoLong = table.Column<decimal>(type: "decimal(9, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryBounds", x => x.BoundaryID);
                    table.ForeignKey(
                        name: "FK_TerritoryBounds_Territories_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Cedar Crest Spanish" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 1, null, "English" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 2, null, "Español" });

            migrationBuilder.InsertData(
                table: "PublisherTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Publisher" });

            migrationBuilder.InsertData(
                table: "PublisherTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Pioneer" });

            migrationBuilder.InsertData(
                table: "PublisherTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Elder" });

            migrationBuilder.InsertData(
                table: "TerritoryTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Door to Door" });

            migrationBuilder.InsertData(
                table: "TerritoryTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Telephone" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 1, 1, "Expulsado" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 2, 1, "Peligroso" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 3, 1, "No Visitar" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 4, 1, "Privado" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 5, 1, "Vacio" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 6, 1, "Negocio" });

            migrationBuilder.InsertData(
                table: "DoorCodes",
                columns: new[] { "Id", "CongregationID", "Description" },
                values: new object[] { 7, 1, "No desean cartas" });

            migrationBuilder.InsertData(
                table: "Territories",
                columns: new[] { "Id", "Added", "AddedBy", "AssignedPublisherID", "CheckedIn", "CheckedOut", "City", "CongregationID", "LastCheckedInBy", "Modified", "ModifiedBy", "Notes", "TerritoryName", "TerritoryTypeId", "Type" },
                values: new object[] { 1, new DateTime(2021, 12, 13, 10, 19, 47, 977, DateTimeKind.Local).AddTicks(2521), "cyberyaga@hotmail.com", null, null, null, null, 1, null, new DateTime(2021, 12, 13, 10, 19, 47, 977, DateTimeKind.Local).AddTicks(2556), "cyberyaga@hotmail.com", null, "Allentown - 01", null, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2430, 40.584240m, -75.503010m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2431, 40.579930m, -75.502500m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2432, 40.578870m, -75.502400m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2433, 40.577780m, -75.502280m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2434, 40.577100m, -75.502200m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2435, 40.576790m, -75.502170m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2436, 40.576520m, -75.502080m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2437, 40.576260m, -75.501960m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2438, 40.575890m, -75.501690m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2439, 40.575550m, -75.501410m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2440, 40.575070m, -75.501010m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2441, 40.574470m, -75.500530m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2442, 40.574220m, -75.500240m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2443, 40.574080m, -75.500020m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2444, 40.573890m, -75.499710m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2445, 40.573600m, -75.499350m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2446, 40.573350m, -75.499170m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2447, 40.573070m, -75.499030m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2448, 40.572670m, -75.498960m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2449, 40.572510m, -75.498980m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2450, 40.572370m, -75.499000m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2451, 40.571590m, -75.499210m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2452, 40.571050m, -75.499350m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2453, 40.570610m, -75.499450m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2454, 40.570320m, -75.499470m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2455, 40.570070m, -75.499470m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2456, 40.569860m, -75.499460m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2457, 40.569500m, -75.499390m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2458, 40.569210m, -75.499300m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2459, 40.568420m, -75.498920m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2460, 40.567320m, -75.498280m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2461, 40.566620m, -75.497890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2462, 40.565930m, -75.497500m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2463, 40.564660m, -75.484860m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2464, 40.571450m, -75.481290m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2465, 40.571880m, -75.481070m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2466, 40.572390m, -75.480890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2467, 40.572760m, -75.480830m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2468, 40.574330m, -75.480820m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2469, 40.575870m, -75.480840m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2470, 40.577110m, -75.480830m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2471, 40.577620m, -75.480820m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2472, 40.578170m, -75.480810m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2473, 40.578670m, -75.480700m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2474, 40.578800m, -75.480670m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2475, 40.578910m, -75.480610m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2476, 40.579130m, -75.480510m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2477, 40.579340m, -75.480420m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2478, 40.579570m, -75.480310m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2479, 40.579910m, -75.480080m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2480, 40.580170m, -75.479850m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2481, 40.580360m, -75.479640m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2482, 40.580410m, -75.479590m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2483, 40.580550m, -75.479430m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2484, 40.580630m, -75.479350m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2485, 40.580700m, -75.479260m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2486, 40.580860m, -75.479100m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2487, 40.581040m, -75.478900m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2488, 40.581130m, -75.478800m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2489, 40.581270m, -75.478650m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2490, 40.581410m, -75.478490m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2491, 40.581550m, -75.478340m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2492, 40.581600m, -75.478290m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2493, 40.581750m, -75.478120m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2494, 40.581790m, -75.478070m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2495, 40.581830m, -75.478030m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2496, 40.581870m, -75.477980m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2497, 40.581920m, -75.477940m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2498, 40.581950m, -75.477900m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2499, 40.581990m, -75.477850m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2500, 40.582070m, -75.477770m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2501, 40.582180m, -75.477650m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2502, 40.582290m, -75.477520m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2503, 40.582340m, -75.477610m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2504, 40.582380m, -75.477680m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2505, 40.582480m, -75.477840m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2506, 40.582610m, -75.478030m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2507, 40.582670m, -75.478110m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2508, 40.582740m, -75.478200m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2509, 40.582890m, -75.478340m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2510, 40.583040m, -75.478470m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2511, 40.583150m, -75.478550m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2512, 40.583260m, -75.478630m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2513, 40.583280m, -75.478650m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2514, 40.583330m, -75.478740m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2515, 40.583390m, -75.478820m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2516, 40.583530m, -75.478800m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2517, 40.583680m, -75.478780m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2518, 40.583950m, -75.478740m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2519, 40.584100m, -75.478740m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2520, 40.584280m, -75.478750m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2521, 40.584490m, -75.478780m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2522, 40.584720m, -75.478830m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2523, 40.585090m, -75.478880m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2524, 40.585300m, -75.478910m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2525, 40.585520m, -75.478940m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2526, 40.585490m, -75.479060m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2527, 40.585480m, -75.479190m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2528, 40.585510m, -75.479260m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2529, 40.585530m, -75.479300m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2530, 40.585550m, -75.479350m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2531, 40.585730m, -75.479610m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2532, 40.585930m, -75.479910m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2533, 40.586170m, -75.480270m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2534, 40.586390m, -75.480600m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2535, 40.586560m, -75.480860m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2536, 40.586660m, -75.481010m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2537, 40.586890m, -75.481380m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2538, 40.587090m, -75.481670m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2539, 40.587340m, -75.482060m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2540, 40.587650m, -75.482540m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2541, 40.587900m, -75.482910m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2542, 40.588140m, -75.483270m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2543, 40.588230m, -75.483380m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2544, 40.588300m, -75.483500m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2545, 40.588360m, -75.483600m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2546, 40.588380m, -75.483660m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2547, 40.588410m, -75.483720m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2548, 40.588490m, -75.483990m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2549, 40.588580m, -75.484400m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2550, 40.588590m, -75.484890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2551, 40.588470m, -75.486060m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2552, 40.588410m, -75.486710m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2553, 40.588420m, -75.486980m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2554, 40.588460m, -75.487240m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2555, 40.588600m, -75.487560m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2556, 40.588830m, -75.487770m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2557, 40.589100m, -75.487880m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2558, 40.589370m, -75.488030m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2559, 40.589680m, -75.488160m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2560, 40.590000m, -75.488330m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2561, 40.589930m, -75.488530m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2562, 40.589850m, -75.488720m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2563, 40.589700m, -75.489040m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2564, 40.589550m, -75.489350m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2565, 40.589390m, -75.489680m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2566, 40.589320m, -75.489840m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2567, 40.589250m, -75.490010m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2568, 40.589180m, -75.490250m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2569, 40.589130m, -75.490480m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2570, 40.589070m, -75.491090m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2571, 40.589030m, -75.491450m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2572, 40.588980m, -75.491910m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2573, 40.588950m, -75.492100m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2574, 40.588920m, -75.492300m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2575, 40.588890m, -75.492490m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2576, 40.588840m, -75.492680m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2577, 40.588780m, -75.492890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2578, 40.588730m, -75.493030m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2579, 40.588640m, -75.493260m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2580, 40.588400m, -75.493770m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2581, 40.588230m, -75.494110m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2582, 40.588050m, -75.494480m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2583, 40.587890m, -75.494800m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2584, 40.587730m, -75.495120m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2585, 40.587570m, -75.495400m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2586, 40.587410m, -75.495660m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2587, 40.587260m, -75.495870m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2588, 40.587180m, -75.495990m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2589, 40.587110m, -75.496110m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2590, 40.587020m, -75.496310m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2591, 40.586940m, -75.496510m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2592, 40.586860m, -75.496770m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2593, 40.586790m, -75.497000m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2594, 40.586610m, -75.497600m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2595, 40.586510m, -75.497890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2596, 40.586410m, -75.498210m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2597, 40.586280m, -75.498650m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2598, 40.586190m, -75.498890m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2599, 40.586060m, -75.499170m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2600, 40.585920m, -75.499430m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2601, 40.585780m, -75.499610m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2602, 40.585650m, -75.499780m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2603, 40.585370m, -75.500110m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2604, 40.585110m, -75.500400m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2605, 40.584870m, -75.500660m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2606, 40.584750m, -75.500820m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2607, 40.584660m, -75.500970m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2608, 40.584580m, -75.501080m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2609, 40.584530m, -75.501210m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2610, 40.584480m, -75.501330m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2611, 40.584430m, -75.501470m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2612, 40.584400m, -75.501590m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2613, 40.584370m, -75.501700m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2614, 40.584340m, -75.501820m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2615, 40.584320m, -75.501950m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2616, 40.584300m, -75.502240m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2617, 40.584280m, -75.502550m, 1 });

            migrationBuilder.InsertData(
                table: "TerritoryBounds",
                columns: new[] { "BoundaryID", "GeoLat", "GeoLong", "TerritoryID" },
                values: new object[] { 2618, 40.584240m, -75.503010m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoorCodes_CongregationID",
                table: "DoorCodes",
                column: "CongregationID");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_DoorCodeID",
                table: "Doors",
                column: "DoorCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_LanguageID",
                table: "Doors",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_TerritoryID",
                table: "Doors",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CongregationID",
                table: "Languages",
                column: "CongregationID");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_CongregationID",
                table: "Territories",
                column: "CongregationID");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_TerritoryTypeId",
                table: "Territories",
                column: "TerritoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryAccess_TerritoryId",
                table: "TerritoryAccess",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryBounds_TerritoryID",
                table: "TerritoryBounds",
                column: "TerritoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "PublisherTypes");

            migrationBuilder.DropTable(
                name: "TerritoryAccess");

            migrationBuilder.DropTable(
                name: "TerritoryBounds");

            migrationBuilder.DropTable(
                name: "URLMinimizeStore");

            migrationBuilder.DropTable(
                name: "DoorCodes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Congregations");

            migrationBuilder.DropTable(
                name: "TerritoryTypes");
        }
    }
}
