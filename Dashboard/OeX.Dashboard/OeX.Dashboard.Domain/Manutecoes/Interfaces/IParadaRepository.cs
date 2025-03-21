namespace OeX.Dashboard.Domain.Manutecoes.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<int> CountTotalByMonth(int month, int year, int idMaquina);
    }
}
