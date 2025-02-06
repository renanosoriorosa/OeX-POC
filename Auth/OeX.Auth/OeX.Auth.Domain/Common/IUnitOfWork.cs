namespace OeX.Auth.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
