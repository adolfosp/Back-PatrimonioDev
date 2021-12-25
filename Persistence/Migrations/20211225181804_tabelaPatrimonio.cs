using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaPatrimonio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Armazenamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaDeVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoriaRAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoEquipamento = table.Column<int>(type: "int", nullable: false),
                    CodigoTipoEquipamento = table.Column<int>(type: "int", nullable: false),
                    FabricanteCodigoTipoEquipamento = table.Column<int>(type: "int", nullable: true),
                    CodigoInformacao = table.Column<int>(type: "int", nullable: false),
                    InformacaoAdicionalCodigoInformacao = table.Column<int>(type: "int", nullable: true),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioCodigoUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.CodigoPatrimonio);
                    table.ForeignKey(
                        name: "FK_Patrimonios_Equipamento_FabricanteCodigoTipoEquipamento",
                        column: x => x.FabricanteCodigoTipoEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "CodigoTipoEquipamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patrimonios_InformacaoAdicional_InformacaoAdicionalCodigoInformacao",
                        column: x => x.InformacaoAdicionalCodigoInformacao,
                        principalTable: "InformacaoAdicional",
                        principalColumn: "CodigoInformacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patrimonios_Usuario_UsuarioCodigoUsuario",
                        column: x => x.UsuarioCodigoUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_FabricanteCodigoTipoEquipamento",
                table: "Patrimonios",
                column: "FabricanteCodigoTipoEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_InformacaoAdicionalCodigoInformacao",
                table: "Patrimonios",
                column: "InformacaoAdicionalCodigoInformacao");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_UsuarioCodigoUsuario",
                table: "Patrimonios",
                column: "UsuarioCodigoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrimonios");
        }
    }
}
