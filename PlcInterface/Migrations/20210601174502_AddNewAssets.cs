using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddNewAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigsTwo",
                table: "ConfigsTwo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigsThree",
                table: "ConfigsThree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigsOne",
                table: "ConfigsOne");

            migrationBuilder.RenameTable(
                name: "ConfigsTwo",
                newName: "ConfigTwo");

            migrationBuilder.RenameTable(
                name: "ConfigsThree",
                newName: "ConfigThree");

            migrationBuilder.RenameTable(
                name: "ConfigsOne",
                newName: "ConfigOne");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigTwo",
                table: "ConfigTwo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigThree",
                table: "ConfigThree",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigOne",
                table: "ConfigOne",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Blow_Moulders",
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
                    Count_In = table.Column<int>(type: "int", nullable: false),
                    Count_Out = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Production_Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blow_Moulders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fillers",
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
                    Count = table.Column<int>(type: "int", nullable: false),
                    Mix_vol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mix_select = table.Column<int>(type: "int", nullable: false),
                    Alarms = table.Column<int>(type: "int", nullable: false),
                    Production_Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Palletizers",
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
                    Packet_No = table.Column<int>(type: "int", nullable: false),
                    Pallet_No = table.Column<int>(type: "int", nullable: false),
                    Production_Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palletizers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blow_Moulders");

            migrationBuilder.DropTable(
                name: "Fillers");

            migrationBuilder.DropTable(
                name: "Palletizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigTwo",
                table: "ConfigTwo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigThree",
                table: "ConfigThree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigOne",
                table: "ConfigOne");

            migrationBuilder.RenameTable(
                name: "ConfigTwo",
                newName: "ConfigsTwo");

            migrationBuilder.RenameTable(
                name: "ConfigThree",
                newName: "ConfigsThree");

            migrationBuilder.RenameTable(
                name: "ConfigOne",
                newName: "ConfigsOne");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigsTwo",
                table: "ConfigsTwo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigsThree",
                table: "ConfigsThree",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigsOne",
                table: "ConfigsOne",
                column: "Id");
        }
    }
}
