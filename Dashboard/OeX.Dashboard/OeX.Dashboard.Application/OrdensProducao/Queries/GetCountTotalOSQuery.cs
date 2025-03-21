using MediatR;

namespace OeX.Dashboard.Application.OrdensProducao.Queries
{
    public class GetCountTotalOSQuery : IRequest<int>
    {
        public int Month { get; set; }
        public int IdMaquina { get; set; }
        public int Year { get; set; }

        public GetCountTotalOSQuery(int month, int year, int idMaquina)
        {
            Month = month;
            IdMaquina = idMaquina;
            Year = year;
        }
    }
}
