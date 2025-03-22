using MediatR;
using OeX.Dashboard.Application.IndicadoresMensais.Interfaces;
using OeX.Dashboard.Application.OrdensProducao.DTOs;

namespace OeX.Dashboard.Application.OrdensProducao.Queries
{
    public class GetQualidadeProducaoMensalHandler
        : IRequestHandler<GetQualidadeProducaoMensal, List<QualidadeProducaoMensalDto>>
    {
        private readonly IIndicadorMensalService _indicadorMensalService;

        public GetQualidadeProducaoMensalHandler(IIndicadorMensalService indicadorMensalService)
        {
            _indicadorMensalService = indicadorMensalService;
        }

        public Task<List<QualidadeProducaoMensalDto>> Handle(GetQualidadeProducaoMensal request, CancellationToken cancellationToken)
        {
            return _indicadorMensalService.GetQualidadeProducaoTodosMeses(request.IdMaquina, request.Year);
        }
    }
}
