using Microsoft.Practices.Unity;
using SystemRestaurantes.ApplicationService;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Services;
using SystemRestaurantes.Infra.Presistence;
using SystemRestaurantes.Infra.Presistence.DataContexts;
using SystemRestaurantes.Infra.Repositories;
using SystemRestaurantes.SharedKernel;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.CrossCutting
{
    public static class DependencyRegister
    {
        /// <param name="conatiner"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestauranteRepository, RestauranteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoRepository, PratoRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUsuarioApplicationService, UsuarioApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestauranteApplicationService, RestauranteApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoApplicationService, PratoApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

        }
    }
}