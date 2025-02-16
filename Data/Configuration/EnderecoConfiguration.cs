using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMNPastel.Models.Domain;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> entity)
        {
            entity.ToTable("Endereco");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NomeRua).HasColumnName("nome_rua");
            entity.Property(e => e.NumeroCasa).HasColumnName("numero_casa");
            entity.Property(e => e.Complemento).HasColumnName("complemento");
            entity.Property(e => e.Bairro).HasColumnName("bairro");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Cidade).HasColumnName("cidade");            
            entity.Property(e => e.Cep).HasColumnName("cep");
            
            entity.HasOne(e => e.Usuario)
                  .WithOne(u => u.Endereco)
                  .HasForeignKey<Usuario>(u => u.EnderecoId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
