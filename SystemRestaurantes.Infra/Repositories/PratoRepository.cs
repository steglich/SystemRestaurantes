using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Domain.Repositories;
using SystemRestaurantes.Domain.Specs;
using SystemRestaurantes.Infra.Presistence.DataContexts;

namespace SystemRestaurantes.Infra.Repositories
{
    public class PratoRepository : IPratoRepository
    {
        private DataContext _context;

        public PratoRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Prato prato)
        {
            _context.Prato.Add(prato);
        }

        public void Delete(Prato prato)
        {
            _context.Prato.Remove(prato);
        }

        public List<Prato> GetAll(string restaurante)
        {
            return _context.Prato.Where(PratoSpecs.GetByRestaurante(restaurante)).OrderBy(x => x.Nome).ToList();
        }

        public Prato GetPrato(string restaurante, string nome)
        {
            return _context.Prato.Where(PratoSpecs.GetPrato(restaurante, nome)).FirstOrDefault();
        }

        public Prato GetOne(string nome)
        {
            return _context.Prato.Where(PratoSpecs.GetOne(nome)).FirstOrDefault();
        }

        public Prato GetId(int id)
        {
            return _context.Prato.Where(PratoSpecs.GetId(id)).FirstOrDefault();
        }

        public void Update(Prato prato)
        {
            _context.Entry<Prato>(prato).State = EntityState.Modified;
        }
    }
}
