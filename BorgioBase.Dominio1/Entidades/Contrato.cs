using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Contratos")]
    public class Contrato : Proposta
    {
        public Contrato()
        {
            Mensalidades = new List<Mensalidade>();
        }
        public string NumeroContrato { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataContrato { get; set; }
        public Decimal ComissaoVendedor { get; set; }
        public Decimal ComissaoCorretora { get; set; }

        public virtual ICollection<Mensalidade> Mensalidades { get; set; }
    }
}
