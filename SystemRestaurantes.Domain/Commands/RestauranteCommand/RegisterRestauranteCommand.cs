namespace SystemRestaurantes.Domain.Commands.RestauranteCommand
{
    public class RegisterRestauranteCommand
    {
        public RegisterRestauranteCommand(string nome, string bairro, string rua, int numero, int usuarioId)
        {
            this.Nome = nome;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
            this.UsuarioId = usuarioId;
        }

        public string Nome { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public int UsuarioId { get; set; }

    }
}
