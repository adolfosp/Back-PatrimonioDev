using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaMovimentacaoEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentacaoEquipamento",
                columns: table => new
                {
                    CodigoMovimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataApropriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEvolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioCodigoUsuario = table.Column<int>(type: "int", nullable: true),
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false),
                    PatrimonioCodigoPatrimonio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoEquipamento", x => x.CodigoMovimentacao);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEquipamento_Patrimonio_PatrimonioCodigoPatrimonio",
                        column: x => x.PatrimonioCodigoPatrimonio,
                        principalTable: "Patrimonio",
                        principalColumn: "CodigoPatrimonio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEquipamento_Usuario_UsuarioCodigoUsuario",
                        column: x => x.UsuarioCodigoUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEquipamento_PatrimonioCodigoPatrimonio",
                table: "MovimentacaoEquipamento",
                column: "PatrimonioCodigoPatrimonio");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEquipamento_UsuarioCodigoUsuario",
                table: "MovimentacaoEquipamento",
                column: "UsuarioCodigoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoEquipamento");
        }
    }
}
