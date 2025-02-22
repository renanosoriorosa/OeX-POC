namespace OeX.Auth.Domain.Usuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ConsultarPaginado(int pageSize, int pageNumber, Guid tenant);
        Task<int> CountTotalUsers();
    }
}
