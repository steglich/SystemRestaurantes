using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.RestauranteCommand;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Services
{
    public interface IRestauranteApplicationService
    {
        List<Restaurante> GetAll();
        List<Restaurante> GetByRestaurante(string email);
        Restaurante GetOne(string nome);
        Restaurante GetId(int id);
        Restaurante Create(RegisterRestauranteCommand command);
        Restaurante Update(UpdateRestauranteCommand command);
        Restaurante Delete(DeleteRestauranteCommand command);
    }
}
