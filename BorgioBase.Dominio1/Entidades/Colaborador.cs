using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Colaboradores")]
    public class Colaborador : PessoaFisica
    {
        public string Cargo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAdmissao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataDemissao { get; set; }

    }
}
