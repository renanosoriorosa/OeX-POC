using Microsoft.EntityFrameworkCore;
using OeX.Auth.Domain.Usuarios;
using OeX.Auth.Domain.Usuarios.Interfaces;
using OeX.Auth.Infrastructure.Context;

namespace OeX.Auth.Infrastructure.Repository.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RNContext db) : base(db)
        {
        }

        public async Task<List<Usuario>> ConsultarPaginado(int pageSize, 
                                                           int pageNumber,
                                                           Guid tenant)
        {
            return await Db.Usuarios
                           .Where(x => x.EmpresaId == tenant)
                           .AsNoTracking()
                           .Skip((pageNumber - 1) * pageSize) // Pula os registros das páginas anteriores
                           .Take(pageSize) // Seleciona a quantidade desejada de registros
                           .ToListAsync();
        }

        public async Task<int> CountTotalUsers()
        {
            return await Db.Usuarios.CountAsync();
        }
    }
}
