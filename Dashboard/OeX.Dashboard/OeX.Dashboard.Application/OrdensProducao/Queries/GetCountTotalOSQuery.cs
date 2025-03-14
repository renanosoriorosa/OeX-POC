using MediatR;

namespace OeX.Dashboard.Application.OrdensProducao.Queries
{
    public class GetCountTotalOSQuery : IRequest<int>
    {
        public int Month { get; set; }

        public GetCountTotalOSQuery(int month)
        {
            Month = month;
        }
    }
}
