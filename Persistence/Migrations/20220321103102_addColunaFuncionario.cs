using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addColunaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoFuncionario",
                table: "Patrimonio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_CodigoFuncionario",
                table: "Patrimonio",
                column: "CodigoFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonio_Funcionario_CodigoFuncionario",
                table: "Patrimonio",
                column: "CodigoFuncionario",
                principalTable: "Funcionario",
                principalColumn: "CodigoFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonio_Funcionario_CodigoFuncionario",
                table: "Patrimonio");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonio_CodigoFuncionario",
                table: "Patrimonio");

            migrationBuilder.DropColumn(
                name: "CodigoFuncionario",
                table: "Patrimonio");
        }
    }
}
