using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.UsuarioCommand;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Services;
using SystemRestaurantes.Infra.Persistence;
using SystemRestaurantes.SharedKernel;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.ApplicationService
{
    public class UsuarioApplicationService : ApplicationServiceBase, IUsuarioApplicationService
    {
        private IUsuarioRepository _repository;
        private IHandler<DomainNotification> _notification;

        public UsuarioApplicationService(IUsuarioRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Usuario Create(RegisterUsuarioCommand command)
        {
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.Perfil);
            usuario.RegisterUsuario();
            _repository.Create(usuario);

            if (Commit())
            {
                return usuario;
            }

            return null;
        }

        public Usuario Delete(DeleteUsuarioCommand command)
        {
            var usuario = _repository.GetByEmail(command.Email);
            _repository.Delete(usuario);

            if (Commit())
            {
                return usuario;
            }

            return null;
        }
    

        public List<Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public Usuario GetAuthenticateUsuario(string email, string senha)
        {
            return _repository.GetAuthenticateUsuario(email, senha);
        }

        public Usuario GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Usuario GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Usuario Update(UpdateUsuarioCommand command)
        {
            var usuario = _repository.GetByEmail(command.Email);
            usuario.UpdateUsuario(command.Nome, command.Email, command.Senha, command.Perfil);
            _repository.Update(usuario);

            if (Commit())
            {
                return usuario;
            }

            return null;
        }
    }
}
