namespace OeX.Dashboard.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
