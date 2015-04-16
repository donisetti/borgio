using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Mensalidades")]
    public class Mensalidade
    {
        [Key]
        public int MensalidadeId { get; set; }

        public Colaborador Corretor { get; set; }

        public Operadora Operadora { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime? Data { get; set; }

        public DateTime? Vencimento { get; set; }

        public Decimal Valor { get; set; }

        public Decimal ComissaoCorretora { get; set; }

        public Decimal ComissaoCorretor { get; set; }

        public DateTime? PagamentoCliente { get; set; }

        public DateTime? PagamentoCorretora { get; set; }

        public DateTime? PagamentoCorretor { get; set; }

    }
}
