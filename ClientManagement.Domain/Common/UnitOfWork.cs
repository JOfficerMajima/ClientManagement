using ClientManagement.Application.Interfaces;
using ClientManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _currentTransaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                return;
            }
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("Transaction is null");
            }

            try
            {
                await SaveChanges();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                await RollbackTransaction();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public async Task RollbackTransaction()
        {
            try
            {
                if (_currentTransaction == null)
                {
                    return;
                }
                await _currentTransaction.RollbackAsync();
            }
            finally
            {
                Dispose();
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
