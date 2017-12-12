using System;
using System.Linq.Expressions;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Specs
{
    public static class RestauranteSpecs
    {
        public static Expression<Func<Restaurante, bool>> GetOne(string nome)
        {
            return x => x.Nome.Equals(nome);
        }
        public static Expression<Func<Restaurante, bool>> GetByRestaurante(string email)
        {
            return x => x.Usuario.Email.Equals(email);
        }
        public static Expression<Func<Restaurante, bool>> GetAll()
        {
            return x => x.Nome.Equals(x.Nome);
        }
        public static Expression<Func<Restaurante, bool>> GetId(int id)
        {
            return x => x.RestauranteId == id;
        }
    }
}
