using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Usuarios")]
    public class Usuario : Entidade
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Papel { get; set; }

        public bool Ativo { get; set; }
    }
}
