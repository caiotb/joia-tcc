using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
   
    [Table("Imagens")]
    public class Imagem 
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }

        public virtual Peca Peca { get; set; }

    }
}
