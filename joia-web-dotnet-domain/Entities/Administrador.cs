using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
    [Table("Administradores")]
    public class Administrador : Pessoa
    {

        [Required]
        public string Senha { get; set; }
        [Required]
        public string NomeUsuario { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
