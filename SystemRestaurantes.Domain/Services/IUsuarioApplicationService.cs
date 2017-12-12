using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.UsuarioCommand;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Services
{
    public interface IUsuarioApplicationService
    {
        Usuario GetAuthenticateUsuario(string email, string senha);
        List<Usuario> GetAll();
        Usuario GetByEmail(string email);
        Usuario GetId(int id);
        Usuario Create(RegisterUsuarioCommand command);
        Usuario Update(UpdateUsuarioCommand command);
        Usuario Delete(DeleteUsuarioCommand command);
    }
}
