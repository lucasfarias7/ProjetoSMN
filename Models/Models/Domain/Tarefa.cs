using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Models.Domain
{
    public class Tarefa : BaseEntity<int>
    {
        public string? Mensagem { get; set; }
        public DateTime? DataLimite { get; set; }
        public int? SubordinadoId { get; set; }
        public virtual Usuario? Subordinado { get; set; }
    }
}
