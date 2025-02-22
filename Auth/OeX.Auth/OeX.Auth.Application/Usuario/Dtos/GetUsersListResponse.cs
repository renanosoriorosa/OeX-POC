using OeX.Auth.Application.Usuarios.Dtos;

namespace OeX.Auth.Application.Usuarios.Dtos
{
    public class GetUsersListResponse
    {
        public List<UsuarioDto> Usuarios { get; set; }

        public int TotalCount { get; set; }

        public GetUsersListResponse(List<UsuarioDto> usuarios, int totalCount)
        {
            Usuarios = usuarios;
            TotalCount = totalCount;
        }
    }
}
