using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Specs;
using SystemRestaurantes.Infra.Presistence.DataContexts;

namespace SystemRestaurantes.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public Usuario GetAuthenticateUsuario(string email, string senha)
        {
            return _context.Usuario.Where(UsuarioSpecs.AuthenticateUsuario(email, senha)).FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuario.Where(UsuarioSpecs.GetByEmail(email)).FirstOrDefault();
        }

        public Usuario GetId(int id)
        {
            return _context.Usuario.Where(UsuarioSpecs.GetId(id)).FirstOrDefault();
        }

        public void Update(Usuario usuario)
        {
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;
        }
    }
}
