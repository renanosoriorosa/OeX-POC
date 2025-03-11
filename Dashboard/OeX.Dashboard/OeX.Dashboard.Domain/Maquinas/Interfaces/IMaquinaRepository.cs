namespace OeX.Dashboard.Domain.Maquinas.Interfaces
{
    public interface IMaquinaRepository
    {
        Task<List<Maquina>> GetAll();
    }
}
