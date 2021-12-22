using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CodigoEmpresa = table.Column<int>(type: "int", nullable: false),
                    CodigoSetor = table.Column<int>(type: "int", nullable: false),
                    CodigoPermissao = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Usuario_UsuarioPermissao_CodigoPermissao",
                        column: x => x.CodigoPermissao,
                        principalTable: "UsuarioPermissao",
                        principalColumn: "CodigoUsuarioPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoEmpresa",
                table: "Usuario",
                column: "CodigoEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoPermissao",
                table: "Usuario",
                column: "CodigoPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CodigoSetor",
                table: "Usuario",
                column: "CodigoSetor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
