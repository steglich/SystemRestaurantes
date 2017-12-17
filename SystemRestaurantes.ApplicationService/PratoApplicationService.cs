using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.PratoCommand;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Services;
using SystemRestaurantes.Infra.Persistence;
using SystemRestaurantes.SharedKernel;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.ApplicationService
{
    public class PratoApplicationService : ApplicationServiceBase, IPratoApplicationService
    {
        private IPratoRepository _repository;
        private IHandler<DomainNotification> _notification;

        public PratoApplicationService(IPratoRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Prato Create(RegisterPratoCommand command)
        {
            var prato = new Prato(command.Nome, command.Preco, command.RestauranteId);
            prato.RegisterPrato();
            _repository.Create(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }

        public Prato Delete(DeletePratoCommand command)
        {
            var prato = _repository.GetOne(command.Nome);
            _repository.Delete(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }

        public List<Prato> GetAll(string restaurante)
        {
            return _repository.GetAll(restaurante);
        }

        public Prato GetPrato(string restaurante, string prato)
        {
            return _repository.GetPrato(restaurante, prato);
        }

        public Prato GetOne(string prato)
        {
            return _repository.GetOne(prato);
        }

        public Prato GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Prato Update(UpdatePratoCommand command)
        {
            var prato = _repository.GetId(command.PratoId);
            prato.UpdatePrato(command.Nome, command.Preco);
            _repository.Update(prato);

            if (Commit())
            {
                return prato;
            }

            return null;
        }
    }
}
