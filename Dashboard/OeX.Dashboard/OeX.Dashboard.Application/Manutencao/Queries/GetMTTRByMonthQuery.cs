using MediatR;

namespace OeX.Dashboard.Application.Manutencao.Queries
{
    public class GetMTTRByMonthQuery : IRequest<decimal>
    {
        public int Month { get; set; }
        public int IdMaquina { get; set; }

        public GetMTTRByMonthQuery(int month, int idMaquina)
        {
            Month = month;
            IdMaquina = idMaquina;
        }
    }
}
