using joia_web_dotnet_domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{

    [Table("Transacoes")]
    public class Transacao
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoTransacao tipo{ get; set; }
        [Required]
        public string nomeVendedor { get; set; }
        [Required]
        public string nomeComprador { get; set; }
        [Required]
        public DateOnly Data { get; set; }

        public virtual Administrador Administrador { get; set; }

        public ICollection<Peca> Pecas { get; set; }

    }
}
