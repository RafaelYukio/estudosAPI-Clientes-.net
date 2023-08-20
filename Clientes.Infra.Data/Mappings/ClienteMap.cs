using Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.HasKey(cliente => cliente.Id);

            builder.Property(cliente => cliente.NomeCompleto)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(cliente => cliente.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(cliente => cliente.Detalhes)
                .WithOne(detalhes => detalhes.Cliente)
                .HasForeignKey<Detalhes>(detalhes => detalhes.Id);
        }
    }
}
