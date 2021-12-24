using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    CodigoTipoEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEquipamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoFabricante = table.Column<int>(type: "int", nullable: false),
                    FabricanteCodigoFabricante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.CodigoTipoEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_Fabricante_FabricanteCodigoFabricante",
                        column: x => x.FabricanteCodigoFabricante,
                        principalTable: "Fabricante",
                        principalColumn: "CodigoFabricante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_FabricanteCodigoFabricante",
                table: "Equipamento",
                column: "FabricanteCodigoFabricante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}
