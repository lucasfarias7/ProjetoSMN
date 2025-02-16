using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class LoginModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo não pode exceder 50 caracteres.")]
        [DataType(dataType:DataType.EmailAddress)]
        public string EmailLogin { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(16, ErrorMessage = "O tamanho maximo da senha não pode exceder 16 caracteres.")]
        [MinLength(4, ErrorMessage = "O tamanho da senha não pode ser inferior à 4 caracteres.")]
        [DataType(dataType:DataType.Password)]
        public string Senha { get; set; }

        public string? ReturnUrl { get; set; } = null;
    }
}
