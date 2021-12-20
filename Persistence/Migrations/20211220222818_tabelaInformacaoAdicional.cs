using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tabelaInformacaoAdicional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    VersaoWindows = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoAdicional", x => x.CodigoInformacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacaoAdicional");
        }
    }
}
