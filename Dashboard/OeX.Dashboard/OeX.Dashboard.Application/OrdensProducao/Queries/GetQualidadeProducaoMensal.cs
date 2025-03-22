using MediatR;
using OeX.Dashboard.Application.OrdensProducao.DTOs;

namespace OeX.Dashboard.Application.OrdensProducao.Queries
{
    public class GetQualidadeProducaoMensal : IRequest<List<QualidadeProducaoMensalDto>>
    {
        public int Year { get; set; }
        public int IdMaquina { get; set; }

        public GetQualidadeProducaoMensal(int year, int idMaquina)
        {
            Year = year;
            IdMaquina = idMaquina;
        }
    }
}
