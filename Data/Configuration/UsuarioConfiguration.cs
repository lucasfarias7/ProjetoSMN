using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuario");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Nome).HasColumnName("nome");
            entity.Property(u => u.DataNascimento).HasColumnName("data_nasc");
            entity.Property(u => u.TelefoneFixo).HasColumnName("telefone_fixo");
            entity.Property(u => u.NumeroCelular).HasColumnName("numero_celular");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Senha).HasColumnName("senha");
            entity.Property(u => u.Salt).HasColumnName("salt");
            entity.Property(u => u.PrimeiroAcesso).HasColumnName("primeiro_acesso");
            entity.Property(u => u.EnderecoId).HasColumnName("enderecoId");
            entity.Property(u => u.FotoUsuario).HasColumnName("foto_usuario");
            entity.Property(u => u.GestorId).HasColumnName("gestorId");

            entity.HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Usuario>(u => u.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(u => u.Gestor)
                .WithMany()
                .HasForeignKey(u => u.GestorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(u => u.listTarefas)
                .WithOne(t => t.Subordinado)
                .HasForeignKey(t => t.SubordinadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
