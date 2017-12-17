using System.Data.Entity;
using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.Infra.Persistence.Map;

namespace SystemRestaurantes.Infra.Persistence.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base("SystemR")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<Prato> Prato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new RestauranteMap());
            modelBuilder.Configurations.Add(new PratoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}