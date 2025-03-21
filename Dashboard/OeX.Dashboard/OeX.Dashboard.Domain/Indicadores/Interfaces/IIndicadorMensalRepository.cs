using OeX.Dashboard.Domain.Indicadores.Enums;

namespace OeX.Dashboard.Domain.Indicadores.Interfaces
{
    public interface IIndicadorMensalRepository
    {
        Task<IndicadorMensal?> GetIndicadorByMonthAndMaquina(
            int month,
            int year,
            int idMaquina,
            IndicadorEnum indicador);

        Task<List<IndicadorMensal>> GetIndicadorByMonthAllMaquina(
            int month,
            int year,
            IndicadorEnum indicador);
    }
}
