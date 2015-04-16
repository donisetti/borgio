using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Empresas")]
    public class Empresa : PessoaJuridica
    {
        public Empresa()
        {

        }
    }
}
