using AutoMapper;
using MediatR;
using OeX.Auth.Application.Usuarios.Dtos;
using OeX.Auth.Domain.Tenants;
using OeX.Auth.Domain.Usuarios.Interfaces;

namespace OeX.Auth.Application.Usuarios.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersListResponse>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUsuarioRepository userRepository, ITenantService tenantService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<GetUsersListResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _mapper.Map<List<UsuarioDto>>(await _userRepository
                                    .ConsultarPaginado(
                                        request.PageSize,
                                        request.PageNumber,
                                        new Guid(_tenantService.GetTenant())));

                var totalUsers = await _userRepository.CountTotalUsers();

                return new GetUsersListResponse(users, totalUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
