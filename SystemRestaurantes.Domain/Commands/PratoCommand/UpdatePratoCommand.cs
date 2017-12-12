namespace SystemRestaurantes.Domain.Commands.PratoCommand
{
    public class UpdatePratoCommand
    {
        public UpdatePratoCommand(int pratoId, string nome, string preco)
        {
            this.PratoId = pratoId;
            this.Nome = nome;
            this.Preco = preco;
        }

        public int PratoId { get; set; }

        public string Nome { get; private set; }
        public string Preco { get; private set; }
    }
}
