using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holder_Count",
                table: "DPalletizers");

            migrationBuilder.DropColumn(
                name: "Pallet_Count",
                table: "DPalletizers");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "DPalletizers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "DPalletizers");

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
        }
    }
}
