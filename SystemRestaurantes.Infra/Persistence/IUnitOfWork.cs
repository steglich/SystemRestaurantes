using System;

namespace SystemRestaurantes.Infra.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
