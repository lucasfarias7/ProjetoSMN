using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMNPastel.Models.Domain;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Data.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> entity)
        {
            entity.ToTable("Tarefa");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Mensagem).HasColumnName("mensagem");
            entity.Property(u => u.DataLimite).HasColumnName("data_limite");
            entity.Property(u => u.SubordinadoId).HasColumnName("subordinadoId");

            entity.HasOne(u => u.Subordinado)
                .WithMany(s => s.listTarefas)
                .HasForeignKey(u => u.SubordinadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
