using Microsoft.EntityFrameworkCore;
using OeX.Auth.Domain.Common.Interfaces;
using OeX.Auth.Infrastructure.Context;
using System.Linq.Expressions;

namespace OeX.Auth.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly RNContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(RNContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
