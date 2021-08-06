using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddLabelAndDPall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DPalletizers",
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
                    table.PrimaryKey("PK_DPalletizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
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
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DPalletizers");

            migrationBuilder.DropTable(
                name: "Labels");
        }
    }
}
