using OeX.Auth.Domain.Empresas;
using OeX.Auth.Domain.Empresas.Interfaces;
using OeX.Auth.Infrastructure.Context;

namespace OeX.Auth.Infrastructure.Repository.Empresas
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(RNContext db) : base(db)
        {
        }
    }
}
