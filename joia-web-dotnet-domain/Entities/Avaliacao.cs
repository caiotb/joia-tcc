using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int Nota { get; set; }

        public string Comentario { get; set; }

        public virtual Peca Peca { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
