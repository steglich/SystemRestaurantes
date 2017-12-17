using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.RestauranteCommand;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Services;
using SystemRestaurantes.Infra.Persistence;
using SystemRestaurantes.SharedKernel;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.ApplicationService
{
    public class RestauranteApplicationService : ApplicationServiceBase, IRestauranteApplicationService
    {
        private IRestauranteRepository _repository;
        private IHandler<DomainNotification> _notification;

        public RestauranteApplicationService(IRestauranteRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Restaurante Create(RegisterRestauranteCommand command)
        {
            var restaurante = new Restaurante(command.Nome, command.Bairro, command.Rua, command.Numero, command.UsuarioId);
            restaurante.RegisterRestaurante();
            _repository.Create(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }

        public Restaurante Delete(DeleteRestauranteCommand command)
        {
            var restaurante = _repository.GetOne(command.Nome);
            _repository.Delete(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }

        public List<Restaurante> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Restaurante> GetByRestaurante(string email)
        {
            return _repository.GetByRestaurante(email);
        }

        public Restaurante GetOne(string nome)
        {
            return _repository.GetOne(nome);
        }

        public Restaurante GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Restaurante Update(UpdateRestauranteCommand command)
        {
            var restaurante = _repository.GetOne(command.Nome);
            restaurante.UpdateRestaurante(command.Nome, command.Bairro, command.Rua, command.Numero);
            _repository.Update(restaurante);

            if (Commit())
            {
                return restaurante;
            }

            return null;
        }
    }
}
