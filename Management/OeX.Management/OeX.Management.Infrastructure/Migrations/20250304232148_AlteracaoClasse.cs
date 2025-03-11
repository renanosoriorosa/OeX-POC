using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OeX.Management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClasse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_MotivosParada_MotivoParadaId",
                table: "Paradas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_MotivoParadaId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "MotivoManutencaoId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "MotivoParadaId",
                table: "Paradas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotivoManutencaoId",
                table: "Paradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MotivoParadaId",
                table: "Paradas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_MotivoParadaId",
                table: "Paradas",
                column: "MotivoParadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paradas_MotivosParada_MotivoParadaId",
                table: "Paradas",
                column: "MotivoParadaId",
                principalTable: "MotivosParada",
                principalColumn: "Id");
        }
    }
}
