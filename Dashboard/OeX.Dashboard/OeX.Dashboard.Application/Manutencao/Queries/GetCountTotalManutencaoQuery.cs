using MediatR;

namespace OeX.Dashboard.Application.Manutencoes.Queries
{
    public class GetCountTotalManutencaoQuery : IRequest<int>
    {
        public int Month { get; set; }
        public int IdMaquina { get; set; }
        public int Year { get; set; }

        public GetCountTotalManutencaoQuery(int month, int year, int idMaquina)
        {
            Month = month;
            IdMaquina = idMaquina;
            Year = year;
        }
    }
}
