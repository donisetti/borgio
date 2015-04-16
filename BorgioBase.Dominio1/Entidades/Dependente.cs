using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Dependentes")]
    public class Dependente : PessoaFisica
    {
        public int TitularId { get; set; }

        public string Parentesco { get; set; }


    }
}
