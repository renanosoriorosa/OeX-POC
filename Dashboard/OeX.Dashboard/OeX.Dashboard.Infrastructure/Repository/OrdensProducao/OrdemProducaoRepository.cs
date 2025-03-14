using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.OrdensProducao.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository
{
    public class OrdemProducaoRepository : IOrdemProducaoRepository
    {
        private readonly RNContext _context;

        public OrdemProducaoRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<int> CountTotalByMonth(int month)
        {
            return await _context.OrdemProducao
                            .Where(x => x.DataHoraInicio.Month == month)
                            .CountAsync();
        }
    }
}
