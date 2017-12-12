using System.Collections.Generic;
using SystemRestaurantes.Domain.Scopes;

namespace SystemRestaurantes.Domain.Entities
{
    public class Restaurante
    {
        public Restaurante()
        {

        }
        public Restaurante(string nome, string bairro, string rua, int numero, int usuarioId)
        {
            this.Nome = nome;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
            this.UsuarioId = usuarioId;

            this.Prato = new List<Prato>();
        }

        public int RestauranteId { get; set; }

        public string Nome { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Prato> Prato { get; set; }

        public void RegisterRestaurante() => this.CreateRestauranteScopIsValid();
        public void UpdateRestaurante(string nome, string bairro, string rua, int numero)
        {
            if (!this.UpdateRestauranteScopIsValid(nome, bairro, rua, numero))
                return;

            this.Nome = nome;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
        }
    }
}
