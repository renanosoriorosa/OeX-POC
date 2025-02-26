using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OeX.Auth.Domain.Empresas;
using OeX.Auth.Domain.Tenants;
using OeX.Auth.Domain.Usuarios;

namespace OeX.Auth.Infrastructure.Context
{
    public class RNContext : IdentityDbContext<Usuario>
    {
        private readonly ITenantService _tenantService;

        public RNContext(DbContextOptions<RNContext> options,
            ITenantService tenantService) : base(options) 
        {
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

            var tenantId = _tenantService.GetTenant();

            modelBuilder.Entity<Empresa>().HasQueryFilter(u => u.Id.ToString() == tenantId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
