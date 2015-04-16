using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Clientes")]
    public class Cliente : PessoaJuridica
    {
        public Cliente()
        {

        }
    }
}
