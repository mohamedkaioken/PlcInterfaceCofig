using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddPlcConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigsOne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Fault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    H2O = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Syrp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigsOne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigsThree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Fault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PallateCount = table.Column<int>(type: "int", nullable: false),
                    PackCount = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigsThree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigsTwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Fault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionCount = table.Column<int>(type: "int", nullable: false),
                    ActualSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MixVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgramSelection = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigsTwo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigsOne");

            migrationBuilder.DropTable(
                name: "ConfigsThree");

            migrationBuilder.DropTable(
                name: "ConfigsTwo");
        }
    }
}
