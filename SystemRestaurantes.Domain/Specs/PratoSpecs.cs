using System;
using System.Linq.Expressions;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Specs
{
    public static class PratoSpecs
    {
        public static Expression<Func<Prato, bool>> GetByRestaurante(string restaurante)
        {
            return x => x.Restaurante.Nome.Equals(restaurante);
        }
        public static Expression<Func<Prato, bool>> GetPrato(string restaurante, string prato)
        {
            return x => x.Restaurante.Nome.Equals(restaurante) && x.Nome.Equals(prato);
        }
        public static Expression<Func<Prato, bool>> GetOne(string prato)
        {
            return x => x.Nome.Equals(prato);
        }
        public static Expression<Func<Prato, bool>> GetId(int id)
        {
            return x => x.PratoId == id;
        }
    }
}
