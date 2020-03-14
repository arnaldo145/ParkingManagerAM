using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingManagerWebApp.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceControl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    AdditionalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceControl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEntry",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiclePlate = table.Column<string>(nullable: true),
                    OccurrenceDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEntry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleExit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiclePlate = table.Column<string>(nullable: true),
                    OccurrenceDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleExit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceControl");

            migrationBuilder.DropTable(
                name: "VehicleEntry");

            migrationBuilder.DropTable(
                name: "VehicleExit");
        }
    }
}
