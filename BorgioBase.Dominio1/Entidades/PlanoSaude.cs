using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("PlanoSaudes")]

    public class PlanoSaude : Entidade
    {
        public PlanoSaude()
        {
            Operadora = new Operadora();

        }
        [Key]
        public int PlanoSaudeId { get; set; }
        public String Nome { get; set; }
        public Operadora Operadora { get; set; }
        public decimal Comissao { get; set; }
        public int QuantidadeParcelas { get; set; }


    }
}
