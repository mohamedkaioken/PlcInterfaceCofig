using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddMixers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rinse",
                table: "Fillers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mixers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Fault = table.Column<int>(type: "int", nullable: false),
                    Product_Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2_Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Water_Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Syrup_Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Production_Hours = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mixers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mixers");

            migrationBuilder.DropColumn(
                name: "Rinse",
                table: "Fillers");
        }
    }
}
