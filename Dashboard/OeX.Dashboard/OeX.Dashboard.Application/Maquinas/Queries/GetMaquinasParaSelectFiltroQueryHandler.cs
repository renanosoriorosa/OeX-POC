using AutoMapper;
using MediatR;
using OeX.Dashboard.Application.Commons;
using OeX.Dashboard.Domain.Maquinas.Interfaces;

namespace OeX.Dashboard.Application.Maquinas.Queries
{
    public class GetMaquinasParaSelectFiltroQueryHandler : IRequestHandler<GetMaquinasParaSelectFiltroQuery, List<SelectFiltroDto>>
    {
        private readonly IMaquinaRepository _maquinaRepository;
        private readonly IMapper _map;

        public GetMaquinasParaSelectFiltroQueryHandler(IMaquinaRepository maquinaRepository, IMapper map)
        {
            _maquinaRepository = maquinaRepository;
            _map = map;
        }

        public async Task<List<SelectFiltroDto>> Handle(GetMaquinasParaSelectFiltroQuery request, CancellationToken cancellationToken)
        {
            return _map.Map<List<SelectFiltroDto>>(await _maquinaRepository.GetAll());
        }
    }
}
