using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations
{
    public partial class AddBrokerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrokerId",
                table: "ConfigsTwo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrokerId",
                table: "ConfigsThree",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrokerId",
                table: "ConfigsOne",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "ConfigsTwo");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "ConfigsThree");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "ConfigsOne");
        }
    }
}
