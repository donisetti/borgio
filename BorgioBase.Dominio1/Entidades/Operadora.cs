using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Operadoras")]

    public class Operadora : Entidade
    {
        [Key]
        public int OperadoraId { get; set; }

        public String Nome { get; set; }
    }
}
