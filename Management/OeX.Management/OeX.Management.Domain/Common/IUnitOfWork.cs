namespace OeX.Management.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
