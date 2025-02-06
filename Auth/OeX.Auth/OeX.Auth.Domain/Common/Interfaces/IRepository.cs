using OeX.Auth.Domain.Commons;
using System.Linq.Expressions;

namespace OeX.Auth.Domain.Common.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
