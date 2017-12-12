using System.Collections.Generic;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Repositories
{
    public interface IPratoRepository
    {
        List<Prato> GetAll(string restaurante);
        Prato GetPrato(string restaurante, string nome);
        Prato GetOne(string nome);
        Prato GetId(int id);
        void Create(Prato prato);
        void Update(Prato prato);
        void Delete(Prato prato);
    }
}
