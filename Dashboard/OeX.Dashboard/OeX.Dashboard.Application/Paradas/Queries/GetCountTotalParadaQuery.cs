using MediatR;

namespace OeX.Dashboard.Application.Paradas.Queries
{
    public class GetCountTotalParadaQuery : IRequest<int>
    {
        public int Month { get; set; }
        public int IdMaquina { get; set; }

        public GetCountTotalParadaQuery(int month, int idMaquina)
        {
            Month = month;
            IdMaquina = idMaquina;
        }
    }
}
