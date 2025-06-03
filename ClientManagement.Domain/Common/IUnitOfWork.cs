using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
