using System;

namespace SystemRestaurantes.Infra.Presistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
