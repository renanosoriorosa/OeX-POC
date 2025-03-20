using OeX.Dashboard.Domain.Maquinas.Enums;

namespace OeX.Dashboard.Domain.Indicadores.Interfaces
{
    public interface IIndicadorMensalRepository
    {
        Task<IndicadorMensal?> GetIndicadorByMonthAndMaquina(
            int month,
            int idMaquina,
            IndicadorEnum indicador);

        Task<List<IndicadorMensal>> GetIndicadorByMonthAllMaquina(
            int month,
            IndicadorEnum indicador);
    }
}
