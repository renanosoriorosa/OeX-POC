using MediatR;
using OeX.Dashboard.Domain.Paradas.Interfaces;

namespace OeX.Dashboard.Application.Paradas.Queries
{
    public class GetCountTotalParadaQueryHandler : IRequestHandler<GetCountTotalParadaQuery, int>
    {
        private readonly IParadaRepository _repository;

        public GetCountTotalParadaQueryHandler(IParadaRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(GetCountTotalParadaQuery request, CancellationToken cancellationToken)
        {
            return _repository.CountTotalByMonth(request.Month, request.IdMaquina);
        }
    }
}