using System.Data.Entity.ModelConfiguration;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Infra.Presistence.Map
{
    public class RestauranteMap : EntityTypeConfiguration<Restaurante>
    {
        public RestauranteMap()
        {
            ToTable("Restaurantes");

            HasKey(x => x.RestauranteId);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Bairro).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Rua).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Numero).IsRequired();

            HasRequired(x => x.Usuario);
            HasMany(X => X.Prato);
        }
    }
}
