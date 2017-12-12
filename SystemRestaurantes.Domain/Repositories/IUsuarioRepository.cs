using System.Collections.Generic;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetAuthenticateUsuario(string email, string senha);
        List<Usuario> GetAll();
        Usuario GetByEmail(string email);
        Usuario GetId(int id);
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
