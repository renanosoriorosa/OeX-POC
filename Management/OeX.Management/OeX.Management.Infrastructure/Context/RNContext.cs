

using Microsoft.EntityFrameworkCore;
using OeX.Management.Domain.Empresas;
using OeX.Management.Domain.Manutecoes;
using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.Paradas;


namespace OeX.Management.Infrastructure.Context
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

    }
}
