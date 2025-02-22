using MediatR;
using OeX.Auth.Application.Usuarios.Dtos;
using OeX.Auth.Domain.Common;

namespace OeX.Auth.Application.Usuarios.Queries
{
    public class GetUsersQuery : PageList, IRequest<GetUsersListResponse>
    {
    }
}
