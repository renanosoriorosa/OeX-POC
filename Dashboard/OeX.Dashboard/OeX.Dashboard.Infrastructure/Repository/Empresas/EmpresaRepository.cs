using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Empresas.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.Empresas
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly RNContext _context;

        public EmpresaRepository(RNContext context)
        {
            _context = context;
        }

        public void Adicionar(Empresa entity)
        {
            _context.Add(entity);
        }

        public void Atualizar(Empresa entity)
        {
            _context.Update(entity);
        }

        public void Remover(Empresa entity)
        {
            _context.Remove(entity);
        }
    }
}
