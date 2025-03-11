using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OeX.Management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoClasseRetornandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_MotivosParada_MotivoParadaId",
                table: "Paradas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_MotivoParadaId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "MotivoParadaId",
                table: "Paradas");
        }
    }
}
