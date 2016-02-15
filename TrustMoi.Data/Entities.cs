using System.Data.Entity;
using TrustMoi.Data.Base;

namespace TrustMoi.Data
{
    public partial class Entities : IDbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}