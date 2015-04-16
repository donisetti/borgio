using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("PessoasFisicas")]
    public class PessoaFisica : Pessoa
    {
        public int IdEstadoCivil { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        [StringLength(20)]
        public string Rg { get; set; }

        [StringLength(20)]
        public string OrgaoRg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataEmissaoRg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(10)]
        public string Sexo { get; set; }

        [StringLength(100)]
        public string Naturalidade { get; set; }

        [StringLength(100)]
        public string Nacionalidade { get; set; }

        [StringLength(1)]
        public string Raca { get; set; }

        [StringLength(3)]
        public string TipoSangue { get; set; }

        [StringLength(20)]
        public string CnhNumero { get; set; }

        [StringLength(2)]
        public string CnhCategoria { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CnhVencimento { get; set; }

        [StringLength(20)]
        public string TituloEleitoralNumero { get; set; }

        public int? TituloEleitoralZona { get; set; }

        public int? TituloEleitoralSecao { get; set; }

        [StringLength(20)]
        public string ReservistaNumero { get; set; }

        public int? ReservistaCategoria { get; set; }

        [StringLength(200)]
        public string NomeMae { get; set; }

        [StringLength(200)]
        public string NomePai { get; set; }
        [StringLength(20)]
        public string CarteiraNacionalSaude { get; set; }
        [StringLength(20)]
        public string DeclaracaoNascidoVivo { get; set; }
        [StringLength(100)]
        public string PisPasep { get; set; }
        [StringLength(100)]
        public string Profissao { get; set; }
        [StringLength(100)]
        public string PaisOrigem { get; set; }
        [StringLength(20)]
        public string Altura { get; set; }
        [StringLength(20)]
        public string Peso { get; set; }

    }
}