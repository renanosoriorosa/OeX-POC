using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Indicadores;
using OeX.Dashboard.Domain.Manutecoes;
using OeX.Dashboard.Domain.Maquinas;
using OeX.Dashboard.Domain.MotivosManutencao;
using OeX.Dashboard.Domain.MotivosParada;
using OeX.Dashboard.Domain.Paradas;

namespace OeX.Dashboard.Infrastructure.Context
{
    public class RNContext : DbContext
    {
        public RNContext(DbContextOptions<RNContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<MotivoManutencao> MotivosManutencao { get; set; }
        public DbSet<MotivoParada> MotivosParada { get; set; }
        public DbSet<IndicadorMensal> IndicadoresMensal { get; set; }
    }
}
