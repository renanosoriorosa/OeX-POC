using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Indicadores;
using OeX.Dashboard.Domain.Indicadores.Interfaces;
using OeX.Dashboard.Domain.Maquinas.Enums;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository
{
    public class IndicadorMensalRepository : IIndicadorMensalRepository
    {
        private readonly RNContext _context;

        public IndicadorMensalRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<IndicadorMensal?> GetIndicadorByMonthAndMaquina(
            int month,
            int idMaquina,
            IndicadorEnum indicador)
        {
            return await _context.IndicadoresMensal
                            .Where(x => x.Mes == month &&
                                    x.Id == idMaquina &&
                                    x.Indicador == indicador)
                            .FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorMensal>> GetIndicadorByMonthAllMaquina(
            int month,
            IndicadorEnum indicador)
        {
            return await _context.IndicadoresMensal
                            .Where(x => x.Mes == month &&
                                    x.Indicador == indicador)
                            .ToListAsync();
        }
    }
}
