using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
 
    [Table("Reservas")]
    public class Reserva
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }

        public virtual Peca Peca { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
