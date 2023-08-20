using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Clientes.Domain.Entities;

namespace Detalhess.Infra.Data.Mappings
{
    public class DetablhesMap : IEntityTypeConfiguration<Detalhes>
    {
        public void Configure(EntityTypeBuilder<Detalhes> builder)
        {
            builder.ToTable(nameof(Detalhes));

            builder.HasKey(detalhes => detalhes.Id);

            builder.Property(detalhes => detalhes.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(detalhes => detalhes.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(detalhes => detalhes.Cliente)
                .WithOne(cliente => cliente.Detalhes)
                .HasForeignKey<Cliente>(cliente => cliente.Id);
        }
    }
}
