using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Mensagem { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public DateOnly Data { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; }


    }
}
