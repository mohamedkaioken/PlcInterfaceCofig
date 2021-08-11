using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations.Mes
{
    public partial class AddUtilitiesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoilerId",
                table: "Loads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompressorId",
                table: "Loads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaterChemicalTreatmentId",
                table: "Loads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaterPumpId",
                table: "Loads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Boilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boilers_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compressors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compressors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compressors_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterChemicalTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterChemicalTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterChemicalTreatments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterPumps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterPumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterPumps_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loads_BoilerId",
                table: "Loads",
                column: "BoilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_CompressorId",
                table: "Loads",
                column: "CompressorId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_WaterChemicalTreatmentId",
                table: "Loads",
                column: "WaterChemicalTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_WaterPumpId",
                table: "Loads",
                column: "WaterPumpId");

            migrationBuilder.CreateIndex(
                name: "IX_Boilers_FactoryId",
                table: "Boilers",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Compressors_FactoryId",
                table: "Compressors",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterChemicalTreatments_FactoryId",
                table: "WaterChemicalTreatments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterPumps_FactoryId",
                table: "WaterPumps",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Boilers_BoilerId",
                table: "Loads",
                column: "BoilerId",
                principalTable: "Boilers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Compressors_CompressorId",
                table: "Loads",
                column: "CompressorId",
                principalTable: "Compressors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_WaterChemicalTreatments_WaterChemicalTreatmentId",
                table: "Loads",
                column: "WaterChemicalTreatmentId",
                principalTable: "WaterChemicalTreatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_WaterPumps_WaterPumpId",
                table: "Loads",
                column: "WaterPumpId",
                principalTable: "WaterPumps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Boilers_BoilerId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Compressors_CompressorId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_WaterChemicalTreatments_WaterChemicalTreatmentId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_WaterPumps_WaterPumpId",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "Boilers");

            migrationBuilder.DropTable(
                name: "Compressors");

            migrationBuilder.DropTable(
                name: "WaterChemicalTreatments");

            migrationBuilder.DropTable(
                name: "WaterPumps");

            migrationBuilder.DropIndex(
                name: "IX_Loads_BoilerId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_CompressorId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_WaterChemicalTreatmentId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_WaterPumpId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "BoilerId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "CompressorId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "WaterChemicalTreatmentId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "WaterPumpId",
                table: "Loads");
        }
    }
}
