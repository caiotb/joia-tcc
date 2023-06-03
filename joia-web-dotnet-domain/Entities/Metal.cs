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
    [Table("Metais")]
    public class Metal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public TipoPedra Pedra { get; set; }
        [Required]
        public decimal PrecoPorGrama { get; set; }

        public virtual ICollection<Peca> Pecas { get; set; }
    }
}
