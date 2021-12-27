using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaPercaEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PercaEquipamento",
                columns: table => new
                {
                    CodigoPerca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoDaPerca = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false),
                    PatrimonioCodigoPatrimonio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercaEquipamento", x => x.CodigoPerca);
                    table.ForeignKey(
                        name: "FK_PercaEquipamento_Patrimonio_PatrimonioCodigoPatrimonio",
                        column: x => x.PatrimonioCodigoPatrimonio,
                        principalTable: "Patrimonio",
                        principalColumn: "CodigoPatrimonio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PercaEquipamento_PatrimonioCodigoPatrimonio",
                table: "PercaEquipamento",
                column: "PatrimonioCodigoPatrimonio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PercaEquipamento");
        }
    }
}
