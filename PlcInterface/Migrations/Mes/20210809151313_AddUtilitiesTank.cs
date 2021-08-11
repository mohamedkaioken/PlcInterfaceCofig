using Microsoft.EntityFrameworkCore.Migrations;

namespace PlcInterface.Migrations.Mes
{
    public partial class AddUtilitiesTank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Loads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loads_TankId",
                table: "Loads",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_FactoryId",
                table: "Tanks",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Tanks_TankId",
                table: "Loads",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Tanks_TankId",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Loads_TankId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Loads");
        }
    }
}
