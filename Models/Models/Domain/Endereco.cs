using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Models.Domain
{
    public class Endereco : BaseEntity<int>
    {
        public string? NomeRua { get; set; }
        public int? NumeroCasa { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }        
        public virtual Usuario? Usuario { get; set; }
    }
}
