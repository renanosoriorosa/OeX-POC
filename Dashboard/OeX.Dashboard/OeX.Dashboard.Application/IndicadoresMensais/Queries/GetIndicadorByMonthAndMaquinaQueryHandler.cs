using MediatR;
using OeX.Dashboard.Application.IndicadoresMensais.Interfaces;

namespace OeX.Dashboard.Application.IndicadoresMensais.Queries
{
    public class GetIndicadorByMonthAndMaquinaQueryHandler : IRequestHandler<GetIndicadorByMonthAndMaquinaQuery, decimal>
    {
        private readonly IIndicadorMensalService _indicadorMensalService;

        public GetIndicadorByMonthAndMaquinaQueryHandler(IIndicadorMensalService indicadorMensalService)
        {
            _indicadorMensalService = indicadorMensalService;
        }

        public async Task<decimal> Handle(GetIndicadorByMonthAndMaquinaQuery request, CancellationToken cancellationToken)
        {
            return await _indicadorMensalService
                            .GetIndicadorByMonthAndMaquina(
                                request.IdMaquina, 
                                request.Month, 
                                request.Year, 
                                request.Indicador);
        }
    }
}
