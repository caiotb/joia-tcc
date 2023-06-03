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
    [Table("Pecas")]
    public class Peca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public TipoPublico Publico { get; set; }

        [NotMapped]
        public decimal Preco { get; set; }

        [Required]
        public TipoPeca Tipo { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Codigo { get; set; }

        public virtual Metal Metal { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public ICollection<Transacao> Transacoes { get; set; }
    }
}
