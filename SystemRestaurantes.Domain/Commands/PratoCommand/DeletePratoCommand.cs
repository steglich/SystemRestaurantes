namespace SystemRestaurantes.Domain.Commands.PratoCommand
{
    public class DeletePratoCommand
    {
        public DeletePratoCommand(string nome)
        {
            this.Nome = nome;
        }
        
        public string Nome { get; private set; }
    }
}
