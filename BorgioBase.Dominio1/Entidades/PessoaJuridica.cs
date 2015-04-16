using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("PessoasJuridicas")]
    public class PessoaJuridica : Pessoa
    {

        //public int IdPessoa { get; set; }

        [StringLength(16)]
        public string Cnpj { get; set; }

        [StringLength(150)]
        public string Fantasia { get; set; }

        [StringLength(30)]
        public string InscricaoMunicipal { get; set; }

        [StringLength(30)]
        public string InscricaoEstadual { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataConstituicao { get; set; }

        [StringLength(1)]
        public string TipoRegime { get; set; }

        [StringLength(1)]
        public string Crt { get; set; }

        [StringLength(9)]
        public string Suframa { get; set; }


    }
}
