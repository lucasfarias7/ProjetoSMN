using Microsoft.EntityFrameworkCore;
using SMNPastel.Data.Configuration;
using SMNPastel.Models.Domain;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Data
{
    public class SMNContext : DbContext
    {       
        public SMNContext(DbContextOptions<SMNContext> options)
            :base(options)
        {            
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
        }
    }
}
