using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Indicadores;
using OeX.Dashboard.Domain.Indicadores.Enums;
using OeX.Dashboard.Domain.Indicadores.Interfaces;
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
            int year,
            int idMaquina,
            IndicadorEnum indicador)
        {
            return await _context.IndicadoresMensal
                            .Where(x => x.Mes == month &&
                                    x.MaquinaId == idMaquina &&
                                    x.Ano == year &&
                                    x.Indicador == indicador)
                            .FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorMensal>> GetIndicadorByMonthAllMaquina(
            int month,
            int year,
            IndicadorEnum indicador)
        {
            return await _context.IndicadoresMensal
                            .Where(x => x.Mes == month &&
                                    x.Ano == year &&
                                    x.Indicador == indicador)
                            .ToListAsync();
        }
    }
}
