namespace SMNPastel.Models.Domain.Autenticacao
{
    public class Usuario : BaseEntity<int>
    {
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? TelefoneFixo { get; set; }
        public string? NumeroCelular { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Salt { get; set; }
        public bool? PrimeiroAcesso { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public byte[]? FotoUsuario { get; set; }
        public int? GestorId { get; set; }
        public virtual Usuario? Gestor { get; set; }
        public virtual List<Tarefa> listTarefas { get; set; } = new List<Tarefa>();

    }
}
