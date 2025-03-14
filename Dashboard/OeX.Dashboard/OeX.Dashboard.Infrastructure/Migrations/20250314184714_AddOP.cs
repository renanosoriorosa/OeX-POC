using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OeX.Dashboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemProducao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    QuanrtidadePrevista = table.Column<int>(type: "int", nullable: false),
                    QuanrtidadeProduzida = table.Column<int>(type: "int", nullable: false),
                    QuanrtidadePerdida = table.Column<int>(type: "int", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false),
                    ManagementId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemProducao_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdemProducao_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_EmpresaId",
                table: "OrdemProducao",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_MaquinaId",
                table: "OrdemProducao",
                column: "MaquinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemProducao");
        }
    }
}
