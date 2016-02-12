using System;

namespace TrustMoi.Data.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool TryComplete();
    }
}