using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Entities
{

    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        public string Cidade { get; set; }
        [Required]
        public string Telefone { get; set; }

        public ICollection<Notificacao> Notificacoes { get; set; }

    }
}
