using MediatR;
using OeX.Dashboard.Application.Commons;
using System.Net;

namespace OeX.Dashboard.Application.Maquinas.Queries
{
    public class GetMaquinasParaSelectFiltroQuery : IRequest<List<SelectFiltroDto>>
    {
    }
}
