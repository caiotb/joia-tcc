using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
    [Table("Clientes")]
    public class Cliente : Pessoa
    {

        [Required]
        public string Senha { get; set; }
        [Required]
        public string NomeUsuario { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }


    }
}
