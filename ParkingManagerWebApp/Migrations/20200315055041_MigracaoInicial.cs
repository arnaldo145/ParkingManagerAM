using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingManagerWebApp.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBParkingStay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiclePlate = table.Column<string>(maxLength: 8, nullable: false),
                    Entry = table.Column<DateTime>(nullable: false),
                    Exit = table.Column<DateTime>(nullable: true),
                    TotalValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParkingStay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPriceControl",
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
                    table.PrimaryKey("PK_TBPriceControl", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBParkingStay");

            migrationBuilder.DropTable(
                name: "TBPriceControl");
        }
    }
}
