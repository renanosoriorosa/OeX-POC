using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OeX.Dashboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndicadorMensal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicadoresMensal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Indicador = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresMensal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadoresMensal_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndicadoresMensal_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresMensal_EmpresaId",
                table: "IndicadoresMensal",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresMensal_MaquinaId",
                table: "IndicadoresMensal",
                column: "MaquinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadoresMensal");
        }
    }
}
