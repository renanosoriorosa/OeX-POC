using OeX.Dashboard.Application.OrdensProducao.DTOs;
using OeX.Dashboard.Domain.Indicadores.Enums;

namespace OeX.Dashboard.Application.IndicadoresMensais.Interfaces
{
    public interface IIndicadorMensalService
    {
        Task<decimal> GetIndicadorByMonthAndMaquina(
            int IdMaquina,
            int Month,
            int year,
            IndicadorEnum indicador);

        Task<List<QualidadeProducaoMensalDto>> GetQualidadeProducaoTodosMeses(
            int IdMaquina,
            int Year);
    }
}
