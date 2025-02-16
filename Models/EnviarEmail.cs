using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EnviarEmail
    {
        public string? Destinatario { get; set; }
        public string? Assunto { get; set; }
        public string? Mensagem { get; set; }
    }
}
