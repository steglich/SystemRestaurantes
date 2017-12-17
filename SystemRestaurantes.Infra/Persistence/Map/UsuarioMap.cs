using System.Data.Entity.ModelConfiguration;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Infra.Persistence.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");

            HasKey(x => x.UsuarioId);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(60).IsRequired();
            Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Senha).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Perfil).HasColumnType("varchar").HasMaxLength(13).IsRequired();
            
        }
    }
}
