using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaTodas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaEquipamento",
                columns: table => new
                {
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEquipamento", x => x.CodigoCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    CodigoEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.CodigoEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    CodigoFabricante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFabricante = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.CodigoFabricante);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    CodigoSetor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.CodigoSetor);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermissao",
                columns: table => new
                {
                    CodigoUsuarioPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoPermissao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermissao", x => x.CodigoUsuarioPermissao);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    CodigoTipoEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEquipamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoFabricante = table.Column<int>(type: "int", nullable: false),
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.CodigoTipoEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_CategoriaEquipamento_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "CategoriaEquipamento",
                        principalColumn: "CodigoCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_Fabricante_CodigoFabricante",
                        column: x => x.CodigoFabricante,
                        principalTable: "Fabricante",
                        principalColumn: "CodigoFabricante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoEmpresa = table.Column<int>(type: "int", nullable: true),
                    CodigoSetor = table.Column<int>(type: "int", nullable: true),
                    CodigoUsuarioPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodigoUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_CodigoEmpresa",
                        column: x => x.CodigoEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "CodigoEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Setor_CodigoSetor",
                        column: x => x.CodigoSetor,
                        principalTable: "Setor",
                        principalColumn: "CodigoSetor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_UsuarioPermissao_CodigoUsuarioPermissao",
                        column: x => x.CodigoUsuarioPermissao,
                        principalTable: "UsuarioPermissao",
                        principalColumn: "CodigoUsuarioPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonio",
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
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonio", x => x.CodigoPatrimonio);
                    table.ForeignKey(
                        name: "FK_Patrimonio_Equipamento_CodigoTipoEquipamento",
                        column: x => x.CodigoTipoEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "CodigoTipoEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patrimonio_Usuario_CodigoUsuario",
                        column: x => x.CodigoUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacaoAdicional",
                columns: table => new
                {
                    CodigoInformacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorPago = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExpericaoGarantia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Antivirus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersaoWindows = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoAdicional", x => x.CodigoInformacao);
                    table.ForeignKey(
                        name: "FK_InformacaoAdicional_Patrimonio_CodigoPatrimonio",
                        column: x => x.CodigoPatrimonio,
                        principalTable: "Patrimonio",
                        principalColumn: "CodigoPatrimonio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoEquipamento",
                columns: table => new
                {
                    CodigoMovimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataApropriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEvolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovimentacaoDoEquipamento = table.Column<int>(type: "int", nullable: false),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoEquipamento", x => x.CodigoMovimentacao);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEquipamento_Patrimonio_CodigoPatrimonio",
                        column: x => x.CodigoPatrimonio,
                        principalTable: "Patrimonio",
                        principalColumn: "CodigoPatrimonio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEquipamento_Usuario_CodigoUsuario",
                        column: x => x.CodigoUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PercaEquipamento",
                columns: table => new
                {
                    CodigoPerca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoDaPerca = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CodigoPatrimonio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercaEquipamento", x => x.CodigoPerca);
                    table.ForeignKey(
                        name: "FK_PercaEquipamento_Patrimonio_CodigoPatrimonio",
                        column: x => x.CodigoPatrimonio,
                        principalTable: "Patrimonio",
                        principalColumn: "CodigoPatrimonio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CodigoCategoria",
                table: "Equipamento",
                column: "CodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CodigoFabricante",
                table: "Equipamento",
                column: "CodigoFabricante");

            migrationBuilder.CreateIndex(
                name: "IX_InformacaoAdicional_CodigoPatrimonio",
                table: "InformacaoAdicional",
                column: "CodigoPatrimonio");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEquipamento_CodigoPatrimonio",
                table: "MovimentacaoEquipamento",
                column: "CodigoPatrimonio");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEquipamento_CodigoUsuario",
                table: "MovimentacaoEquipamento",
                column: "CodigoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_CodigoTipoEquipamento",
                table: "Patrimonio",
                column: "CodigoTipoEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_CodigoUsuario",
                table: "Patrimonio",
                column: "CodigoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PercaEquipamento_CodigoPatrimonio",
                table: "PercaEquipamento",
                column: "CodigoPatrimonio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoEmpresa",
                table: "Usuario",
                column: "CodigoEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoSetor",
                table: "Usuario",
                column: "CodigoSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoUsuarioPermissao",
                table: "Usuario",
                column: "CodigoUsuarioPermissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacaoAdicional");

            migrationBuilder.DropTable(
                name: "MovimentacaoEquipamento");

            migrationBuilder.DropTable(
                name: "PercaEquipamento");

            migrationBuilder.DropTable(
                name: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CategoriaEquipamento");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "UsuarioPermissao");
        }
    }
}
