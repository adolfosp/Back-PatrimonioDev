using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoCategoria",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CodigoCategoria",
                table: "Equipamento",
                column: "CodigoCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_CategoriaEquipamento_CodigoCategoria",
                table: "Equipamento",
                column: "CodigoCategoria",
                principalTable: "CategoriaEquipamento",
                principalColumn: "CodigoCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_CategoriaEquipamento_CodigoCategoria",
                table: "Equipamento");

            migrationBuilder.DropTable(
                name: "CategoriaEquipamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_CodigoCategoria",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "CodigoCategoria",
                table: "Equipamento");
        }
    }
}
