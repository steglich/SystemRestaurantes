namespace SystemRestaurantes.Domain.Commands.UsuarioCommand
{
    public class UpdateUsuarioCommand
    {
        public UpdateUsuarioCommand(int id, string nome, string email, string senha, string perfil)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Perfil = perfil;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
