namespace SystemRestaurantes.Domain.Commands.RetauranteCommand
{
    public class UpdateRestauranteCommand
    {
        public UpdateRestauranteCommand(int restauranteId, string nome, string bairro, string rua, int numero)
        {
            this.RestauranteId = restauranteId;
            this.Nome = nome;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
        }

        public int RestauranteId { get; set; }

        public string Nome { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
    }
}
