using System.Data.Entity.ModelConfiguration;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Infra.Persistence.Map
{
    public class PratoMap : EntityTypeConfiguration<Prato>
    {
        public PratoMap()
        {
            ToTable("Pratos");

            HasKey(x => x.PratoId);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Preco).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            HasRequired(x => x.Restaurante);
        }
    }
}
