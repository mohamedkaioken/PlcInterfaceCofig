using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddCartonizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counts",
                table: "DPalletizers");

            migrationBuilder.AddColumn<decimal>(
                name: "Co2_Consumption",
                table: "Fillers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Holder_Count",
                table: "DPalletizers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pallet_Count",
                table: "DPalletizers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Cartonizers_Shrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Fault = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Counts = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartonizers_Shrinks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartonizers_Shrinks");

            migrationBuilder.DropColumn(
                name: "Co2_Consumption",
                table: "Fillers");

            migrationBuilder.DropColumn(
                name: "Holder_Count",
                table: "DPalletizers");

            migrationBuilder.DropColumn(
                name: "Pallet_Count",
                table: "DPalletizers");

            migrationBuilder.AddColumn<int>(
                name: "Counts",
                table: "DPalletizers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
