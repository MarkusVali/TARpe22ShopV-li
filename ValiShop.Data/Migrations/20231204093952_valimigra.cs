using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValiShop.Data.Migrations
{
    public partial class valimigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarFilesToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageTitle = table.Column<string>(type: "TEXT", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CarId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFilesToDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Mark = table.Column<string>(type: "TEXT", nullable: false),
                    CarShape = table.Column<string>(type: "TEXT", nullable: false),
                    CarType = table.Column<string>(type: "TEXT", nullable: false),
                    LicensePlate = table.Column<string>(type: "TEXT", nullable: false),
                    LicensePlateTemplate = table.Column<string>(type: "TEXT", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeatAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    OriginCountry = table.Column<string>(type: "TEXT", nullable: false),
                    HasAirConditioning = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarSold = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageTitle = table.Column<string>(type: "TEXT", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    SpaceshipId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ListingDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactPhone = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactFax = table.Column<int>(type: "INTEGER", nullable: false),
                    SquareMeters = table.Column<int>(type: "INTEGER", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: true),
                    FloorCount = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomCount = table.Column<int>(type: "INTEGER", nullable: true),
                    BedroomCount = table.Column<int>(type: "INTEGER", nullable: true),
                    BathroomCount = table.Column<int>(type: "INTEGER", nullable: true),
                    WhenEstateListedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPropertySold = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoesHaveSwimmingPool = table.Column<bool>(type: "INTEGER", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FuelType = table.Column<string>(type: "TEXT", nullable: false),
                    FuelCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelConsumption = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    EnginePower = table.Column<int>(type: "INTEGER", nullable: false),
                    DoesHaveAutopilot = table.Column<bool>(type: "INTEGER", nullable: false),
                    CrewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    DoesHaveLifeSupportSystems = table.Column<bool>(type: "INTEGER", nullable: false),
                    BuiltDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaintenanceCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FullTripsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaidenLaunch = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesToApi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExistingFilePath = table.Column<string>(type: "TEXT", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToApi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesToApi_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_RealEstateId",
                table: "FilesToApi",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFilesToDatabase");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "FilesToApi");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "Spaceships");

            migrationBuilder.DropTable(
                name: "RealEstates");
        }
    }
}
