using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations.Mes
{
    public partial class AddUtilitiesTypesNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boilers_Factories_FactoryId",
                table: "Boilers");

            migrationBuilder.DropForeignKey(
                name: "FK_Compressors_Factories_FactoryId",
                table: "Compressors");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterChemicalTreatments_Factories_FactoryId",
                table: "WaterChemicalTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterPumps_Factories_FactoryId",
                table: "WaterPumps");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "WaterPumps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "WaterChemicalTreatments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Compressors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Boilers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Boilers_Factories_FactoryId",
                table: "Boilers",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compressors_Factories_FactoryId",
                table: "Compressors",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterChemicalTreatments_Factories_FactoryId",
                table: "WaterChemicalTreatments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterPumps_Factories_FactoryId",
                table: "WaterPumps",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boilers_Factories_FactoryId",
                table: "Boilers");

            migrationBuilder.DropForeignKey(
                name: "FK_Compressors_Factories_FactoryId",
                table: "Compressors");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterChemicalTreatments_Factories_FactoryId",
                table: "WaterChemicalTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterPumps_Factories_FactoryId",
                table: "WaterPumps");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "WaterPumps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "WaterChemicalTreatments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Compressors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Boilers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boilers_Factories_FactoryId",
                table: "Boilers",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compressors_Factories_FactoryId",
                table: "Compressors",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterChemicalTreatments_Factories_FactoryId",
                table: "WaterChemicalTreatments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterPumps_Factories_FactoryId",
                table: "WaterPumps",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
