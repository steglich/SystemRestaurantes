using System.Collections.Generic;
using SystemRestaurantes.Domain.Scopes;
using SystemRestaurantes.SharedKernel.Helpers;

namespace SystemRestaurantes.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(string nome, string email, string senha, string perfil)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = StringHelper.Encrypt(senha);
            this.Perfil = perfil;
            
            this.Restaurante = new List<Restaurante>();
        }

        public int UsuarioId { get; set; }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Perfil { get; private set; }

        public virtual ICollection<Restaurante> Restaurante { get; set; }

        public void RegisterUsuario() => this.CreateUsuarioScopIsValid();
        public void UpdateUsuario(string nome, string email, string senha, string perfil)
        {
            if (!this.UpdateUsuarioScopIsValid(nome, email, senha, perfil))
                return;

            this.Nome = nome;
            this.Email = email;
            this.Senha = StringHelper.Encrypt(senha);
            this.Perfil = perfil;
        }

        public void Authenticate(string email, string senha) => this.AuthenticateUsuarioScopIsValid(email, senha);
        
    }
}
