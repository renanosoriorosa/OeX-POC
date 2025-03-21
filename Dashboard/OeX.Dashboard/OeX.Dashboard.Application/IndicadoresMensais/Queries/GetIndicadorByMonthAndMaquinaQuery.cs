using MediatR;
using OeX.Dashboard.Domain.Indicadores.Enums;

namespace OeX.Dashboard.Application.IndicadoresMensais.Queries
{
    public class GetIndicadorByMonthAndMaquinaQuery : IRequest<decimal>
    {
        public int Month { get; set; }
        public int IdMaquina { get; set; }
        public int Year { get; set; }
        public IndicadorEnum Indicador { get; set; }

        public GetIndicadorByMonthAndMaquinaQuery(int month, int year, int idMaquina, IndicadorEnum indicador)
        {
            Month = month;
            IdMaquina = idMaquina;
            Indicador = indicador;
            Year = year;
        }
    }
}
