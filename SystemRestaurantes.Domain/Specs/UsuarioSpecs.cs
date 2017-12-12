using System;
using System.Linq.Expressions;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.SharedKernel.Helpers;

namespace SystemRestaurantes.Domain.Specs
{
    public static class UsuarioSpecs
    {
        public static Expression<Func<Usuario, bool>> AuthenticateUsuario(string email, string senha)
        {
            string encriptedSenha = StringHelper.Encrypt(senha);
            return x => x.Email.Equals(email) && x.Senha.Equals(encriptedSenha);
        }

        public static Expression<Func<Usuario, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<Usuario, bool>> GetAll()
        {
            return x => x.Email.Equals(x.Email);
        }

        public static Expression<Func<Usuario, bool>> GetId(int id)
        {
            return x => x.UsuarioId == id;
        }
    }
}
