using System.ComponentModel.DataAnnotations;

namespace SMNPastel.ViewModel
{
    public class TarefaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Mensagem é obrigatório.")]
        public string Mensagem { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data limite é obrigatório")]
        [Display(Name = "Data Limite")]
        public DateTime? DataLimite { get; set; }

        [Required(ErrorMessage = "Subordinado é obrigatório.")]
        [Display(Name = "Subordinado")]
        public int SubordinadoId { get; set; }
    }
}
