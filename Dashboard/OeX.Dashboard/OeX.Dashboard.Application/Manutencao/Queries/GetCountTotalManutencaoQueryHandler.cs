using MediatR;
using OeX.Dashboard.Domain.Manutecoes.Interfaces;

namespace OeX.Dashboard.Application.Manutencoes.Queries
{
    public class GetCountTotalManutencaoQueryHandler : IRequestHandler<GetCountTotalManutencaoQuery, int>
    {
        private readonly IManutencaoRepository _repository;

        public GetCountTotalManutencaoQueryHandler(IManutencaoRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(GetCountTotalManutencaoQuery request, CancellationToken cancellationToken)
        {
            return _repository.CountTotalByMonth(request.Month, request.IdMaquina);
        }
    }
}