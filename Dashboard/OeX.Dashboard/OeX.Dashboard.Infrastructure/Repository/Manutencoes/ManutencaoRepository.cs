using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Manutecoes.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly RNContext _context;

        public ManutencaoRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<int> CountTotalByMonth(int month, int idMaquina)
        {
            var query = _context.Manutencoes
                            .Where(x => x.DataHoraInicio.Month == month);

            if (idMaquina > 0)
                query.Where(x => x.MaquinaId == idMaquina);

            return await query.CountAsync();
        }
    }
}
