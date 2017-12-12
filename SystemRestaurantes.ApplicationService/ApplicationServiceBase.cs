using SystemRestaurantes.Infra.Presistence;
using SystemRestaurantes.SharedKernel;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.ApplicationService
{
    public class ApplicationServiceBase
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notification;

        public ApplicationServiceBase(IUnitOfWork uof)
        {
            this._unitOfWork = uof;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notification.HasNotifications())
            {
                return false;
            }

            _unitOfWork.Commit();
            return true;
        }
    }
}