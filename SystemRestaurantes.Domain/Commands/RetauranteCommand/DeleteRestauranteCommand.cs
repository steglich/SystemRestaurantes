namespace SystemRestaurantes.Domain.Commands.RetauranteCommand
{
    public class DeleteRestauranteCommand
    {
        public DeleteRestauranteCommand(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; private set; }
    }
}
