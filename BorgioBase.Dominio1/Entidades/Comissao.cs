using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Comissoes")]
    public class Comissao
    {
        [Key]
        public int ComissaoId { get; set; }
        public int MensalidadeId { get; set; }

        public string NumeroContrato { get; set; }

        public Colaborador Corretor { get; set; }

        public Operadora Operadora { get; set; }

        public Decimal ComissaoCorretora { get; set; }

        public Decimal ComissaoCorretor { get; set; }
    }
}
