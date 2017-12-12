using System.Collections.Generic;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Repositories
{
    public interface IRestauranteRepository
    {
        List<Restaurante> GetAll();
        List<Restaurante> GetByRestaurante(string email);
        Restaurante GetOne(string nome);
        Restaurante GetId(int id);
        void Create(Restaurante restaurante);
        void Update(Restaurante restaurante);
        void Delete(Restaurante restaurante);
    }
}
