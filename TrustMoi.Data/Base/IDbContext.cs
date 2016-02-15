using System;
using System.Data.Entity;

namespace TrustMoi.Data.Base
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}