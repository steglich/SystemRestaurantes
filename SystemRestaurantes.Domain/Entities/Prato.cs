using SystemRestaurantes.Domain.Scopes;

namespace SystemRestaurantes.Domain.Entities
{
    public class Prato
    {
        public Prato()
        {

        }
        public Prato(string nome, string preco, int restauranteId)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.RestauranteId = restauranteId;
        }

        public int PratoId { get; set; }

        public string Nome { get; private set; }
        public string Preco { get; private set; }
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; }

        public void RegisterPrato() => this.CreatePratoScopIsValid();
        public void UpdatePrato(string nome, string preco)
        {
            if (!this.UpdatePratoScopIsValid(nome, preco))
                return;

            this.Nome = nome;
            this.Preco = preco;
        }
    }
}
