using System;
using System.Collections.Generic;
using SystemRestaurantes.SharedKernel.Events.Contracts;

namespace SystemRestaurantes.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handler(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
