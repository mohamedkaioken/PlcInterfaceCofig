using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddMixerConsumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MixerConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    ProgramSelect = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SyrupConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CO2Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VolumeOfBottle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MixerConsumptions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MixerConsumptions");
        }
    }
}
