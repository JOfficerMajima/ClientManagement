namespace ClientManagement.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task SaveChanges();
    }
}
