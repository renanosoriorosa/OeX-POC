namespace OeX.Dashboard.Domain.OrdensProducao.Interfaces
{
    public interface IOrdemProducaoRepository
    {
        Task<int> CountTotalByMonth(int month, int year, int idMaquina);
    }
}
