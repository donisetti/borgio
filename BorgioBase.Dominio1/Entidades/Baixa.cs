using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Baixas")]
    public class Baixa
    {
        [Key]
        public int BaixaId { get; set; }
        public int MensalidadeId { get; set; }

        [ForeignKey("OperadoraId")]
        [Required(ErrorMessage = "Proponente Titular é obrigátorio")]
        public Operadora Operadora { get; set; }
        public int OperadoraId { get; set; }

        public DateTime? Data { get; set; }

        public Decimal Valor { get; set; }

        public string Observacao { get; set; }

    }
}
