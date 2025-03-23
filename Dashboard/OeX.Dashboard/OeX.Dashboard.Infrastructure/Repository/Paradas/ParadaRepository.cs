using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Paradas.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository
{
    public class ParadaRepository : IParadaRepository
    {
        private readonly RNContext _context;

        public ParadaRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<int> CountTotalByMonth(int month, int year, int idMaquina)
        {
            var query = _context.Paradas
                            .Where(x => x.DataHoraInicio.Month == month &&
                            x.DataHoraInicio.Year == year);

            if (idMaquina > 0)
                query.Where(x => x.MaquinaId == idMaquina);

            return await query.CountAsync();
        }
    }
}
