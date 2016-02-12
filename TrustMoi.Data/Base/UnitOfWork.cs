using System;
using System.Data.Entity;

namespace TrustMoi.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private DbContextTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public bool TryComplete()
        {
            var isAllGood = true;

            try
            {
                _dbContext.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception exception)
            {
                // ToDo: Log error message

                _transaction.Rollback();
                isAllGood = false;
            }

            return isAllGood;
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                    _transaction?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}