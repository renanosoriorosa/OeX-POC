using OeX.Dashboard.Application.IndicadoresMensais.Interfaces;
using OeX.Dashboard.Application.OrdensProducao.DTOs;
using OeX.Dashboard.Domain.Indicadores.Enums;
using OeX.Dashboard.Domain.Indicadores.Interfaces;
using OeX.Dashboard.Domain.Utils;
using System.Collections.Generic;

namespace OeX.Dashboard.Application.IndicadoresMensais.Services
{
    public class IndicadorMensalService : IIndicadorMensalService
    {
        private readonly IIndicadorMensalRepository _repository;

        public IndicadorMensalService(IIndicadorMensalRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetIndicadorByMonthAndMaquina(
            int IdMaquina,
            int Month,
            int Year,
            IndicadorEnum indicador)
        {
            if (IdMaquina > 0)
            {
                var result = await _repository.GetIndicadorByMonthAndMaquina(
                                    Month,
                                    Year,
                                    IdMaquina,
                                   indicador);

                if (result is null) return 0;

                return result.Valor;
            }
            else
            {
                var result = await _repository.GetIndicadorByMonthAllMaquina(
                                    Month,
                                    Year,
                                    indicador);

                if (!result.Any()) return 0;

                var valor = (decimal)result.Sum(x => x.Valor) / result.Count();

                return OeXMath.TruncateToDecimalPlaces(valor, 2);
            }
        }

        public async Task<List<QualidadeProducaoMensalDto>> GetQualidadeProducaoTodosMeses(
            int IdMaquina,
            int Year)
        {
            try
            {
                List<QualidadeProducaoMensalDto> result = new List<QualidadeProducaoMensalDto>();

                for (int mes = 1; mes <= 12; mes++)
                {
                    var qtdBoa = await GetIndicadorByMonthAndMaquina
                                (IdMaquina, mes, Year, IndicadorEnum.QuantidadeBoa);

                    var qtdRuim = await GetIndicadorByMonthAndMaquina
                                    (IdMaquina, mes, Year, IndicadorEnum.QuantidadeRuim);

                    var qtdPerda = await GetIndicadorByMonthAndMaquina
                                    (IdMaquina, mes, Year, IndicadorEnum.QuantidadePerda);

                    result.Add(new QualidadeProducaoMensalDto(qtdBoa, qtdRuim, qtdPerda, mes));
                }

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
