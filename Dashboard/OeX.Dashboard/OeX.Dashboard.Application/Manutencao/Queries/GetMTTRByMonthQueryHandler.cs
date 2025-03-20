using MediatR;
using OeX.Dashboard.Domain.Indicadores.Interfaces;
using OeX.Dashboard.Domain.Maquinas.Enums;
using OeX.Dashboard.Domain.Utils;

namespace OeX.Dashboard.Application.Manutencao.Queries
{
    public class GetMTTRByMonthQueryHandler : IRequestHandler<GetMTTRByMonthQuery, decimal>
    {
        private readonly IIndicadorMensalRepository _repository;

        public GetMTTRByMonthQueryHandler(IIndicadorMensalRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(GetMTTRByMonthQuery request, CancellationToken cancellationToken)
        {
            if (request.IdMaquina > 0)
            {
                var result = await _repository.GetIndicadorByMonthAndMaquina(
                                    request.Month,
                                    request.IdMaquina,
                                    IndicadorEnum.MTTR);

                if (result is null) return 0;

                return result.Valor;
            }
            else
            {
                var result = await _repository.GetIndicadorByMonthAllMaquina(
                                    request.Month,
                                    IndicadorEnum.MTTR);

                if (!result.Any()) return 0;

                var valor = (decimal)result.Sum(x => x.Valor) / result.Count();

                return OeXMath.TruncateToDecimalPlaces(valor, 2);
            }

        }
    }
}
