namespace SystemRestaurantes.Domain.Commands.UsuarioCommand
{
    public class RegisterUsuarioCommand
    {
        public RegisterUsuarioCommand(string nome, string email, string senha, string perfil)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Perfil = perfil;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
