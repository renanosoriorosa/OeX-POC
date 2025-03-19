namespace OeX.Dashboard.Domain.Paradas.Interfaces
{
    public interface IParadaRepository
    {
        Task<int> CountTotalByMonth(int month, int idMaquina);
    }
}
