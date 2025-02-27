using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OeX.Management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoTrabalho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CapacidadeProdutiva = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquinas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MotivosManutencao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosManutencao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivosManutencao_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MotivosParada",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosParada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivosParada_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoManutencaoId = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Manutencoes_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Manutencoes_MotivosManutencao_MotivoManutencaoId",
                        column: x => x.MotivoManutencaoId,
                        principalTable: "MotivosManutencao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoManutencaoId = table.Column<int>(type: "int", nullable: false),
                    MotivoParadaId = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paradas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paradas_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paradas_MotivosParada_MotivoParadaId",
                        column: x => x.MotivoParadaId,
                        principalTable: "MotivosParada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_EmpresaId",
                table: "Manutencoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_MaquinaId",
                table: "Manutencoes",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_MotivoManutencaoId",
                table: "Manutencoes",
                column: "MotivoManutencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_EmpresaId",
                table: "Maquinas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosManutencao_EmpresaId",
                table: "MotivosManutencao",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosParada_EmpresaId",
                table: "MotivosParada",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_EmpresaId",
                table: "Paradas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_MaquinaId",
                table: "Paradas",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_MotivoParadaId",
                table: "Paradas",
                column: "MotivoParadaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropTable(
                name: "MotivosManutencao");

            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "MotivosParada");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
