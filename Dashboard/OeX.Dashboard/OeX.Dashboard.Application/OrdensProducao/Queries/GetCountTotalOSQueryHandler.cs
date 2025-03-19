using MediatR;
using OeX.Dashboard.Domain.OrdensProducao.Interfaces;

namespace OeX.Dashboard.Application.OrdensProducao.Queries
{
    public class GetCountTotalOSQueryHandler : IRequestHandler<GetCountTotalOSQuery, int>
    {
        private readonly IOrdemProducaoRepository _ordemProducaoRepository;

        public GetCountTotalOSQueryHandler(IOrdemProducaoRepository ordemProducaoRepository)
        {
            _ordemProducaoRepository = ordemProducaoRepository;
        }

        public Task<int> Handle(GetCountTotalOSQuery request, CancellationToken cancellationToken)
        {
            return _ordemProducaoRepository.CountTotalByMonth(request.Month, request.IdMaquina);
        }
    }
}
